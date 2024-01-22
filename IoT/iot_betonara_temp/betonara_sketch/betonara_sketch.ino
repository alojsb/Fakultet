#include <Arduino.h>
#if defined(ESP32)
  #include <WiFi.h>
#elif defined(ESP8266)
  #include <ESP8266WiFi.h>
#endif
#include <Firebase_ESP_Client.h>

//Provide the token generation process info.
#include "addons/TokenHelper.h"
//Provide the RTDB payload printing info and other helper functions.
#include "addons/RTDBHelper.h"

// Insert your network credentials
#define WIFI_SSID "DBZ"
#define WIFI_PASSWORD "ganimedkalisto"

// Insert Firebase project API Key
#define API_KEY "AIzaSyAYde5VpbifBYJKQ8P-gjKVnLfldTGPrCo"

// Insert RTDB URLefine the RTDB URL */
#define DATABASE_URL "https://iot-betonara-rtdb-default-rtdb.europe-west1.firebasedatabase.app/" 

//Define Firebase Data object
FirebaseData fbdo;

FirebaseAuth auth;
FirebaseConfig config;

// declare variables
unsigned long sendDataPrevMillis = 0;
bool signupOK = false;

bool refillOn;
bool cementSeqOn;
bool aggregateSeqOn;
bool waterSeqOn;
bool scaleEmptyingOn;

int redLEDPin = 5;
int yellowLEDPin = 2;
int greenLEDPin = 15;

void setup(){
  Serial.begin(115200);
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("Connecting to Wi-Fi");
  while (WiFi.status() != WL_CONNECTED){
    Serial.print(".");
    delay(300);
  }
  Serial.println();
  Serial.print("Connected with IP: ");
  Serial.println(WiFi.localIP());
  Serial.println();

  /* Assign the api key (required) */
  config.api_key = API_KEY;

  /* Assign the RTDB URL (required) */
  config.database_url = DATABASE_URL;

  /* Sign up */
  if (Firebase.signUp(&config, &auth, "", "")){
    Serial.println("ok");
    signupOK = true;
  }
  else{
    Serial.printf("%s\n", config.signer.signupError.message.c_str());
  }

  /* Assign the callback function for the long running token generation task */
  config.token_status_callback = tokenStatusCallback; //see addons/TokenHelper.h
  
  Firebase.begin(&config, &auth);
  Firebase.reconnectWiFi(true);

  //make the red LED pin output and initially turned off
  pinMode(redLEDPin, OUTPUT);
  digitalWrite(redLEDPin, LOW);
  //make the yellow LED pin output and initially turned off
  pinMode(yellowLEDPin, OUTPUT);
  digitalWrite(yellowLEDPin, LOW);
  //make the green LED pin output and initially turned off
  pinMode(greenLEDPin, OUTPUT);
  digitalWrite(greenLEDPin, LOW);
}

void loop(){
  if (Firebase.ready() && signupOK && (millis() - sendDataPrevMillis > 2000 || sendDataPrevMillis == 0)){
    sendDataPrevMillis = millis();

    Serial.println("------------- print this or else... --------------");


    // Read bool values from the realtime database
    if (Firebase.RTDB.getBool(&fbdo, "/concrete/refillOn")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_boolean) {
        refillOn = fbdo.to<bool>();
      }
    }
    if (Firebase.RTDB.getBool(&fbdo, "/concrete/cementSeqOn")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_boolean) {
        cementSeqOn = fbdo.to<bool>();
      }
    }
    if (Firebase.RTDB.getBool(&fbdo, "/concrete/aggregateSeqOn")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_boolean) {
        aggregateSeqOn = fbdo.to<bool>();
      }
    }
    if (Firebase.RTDB.getBool(&fbdo, "/concrete/waterSeqOn")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_boolean) {
        waterSeqOn = fbdo.to<bool>();
      }
    }
    if (Firebase.RTDB.getBool(&fbdo, "/concrete/scaleEmptyingOn")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_boolean) {
        scaleEmptyingOn = fbdo.to<bool>();
      }
    }

    if (refillOn) {
      digitalWrite(redLEDPin, HIGH);
      digitalWrite(yellowLEDPin, LOW);
      digitalWrite(greenLEDPin, HIGH);
      delay(500);
    } else if (cementSeqOn) {
      digitalWrite(redLEDPin, HIGH);
      digitalWrite(yellowLEDPin, LOW);
      digitalWrite(greenLEDPin, LOW);
      delay(500);
    } else if (aggregateSeqOn) {
      digitalWrite(redLEDPin, LOW);
      digitalWrite(yellowLEDPin, HIGH);
      digitalWrite(greenLEDPin, LOW);
      delay(500);
    } else if (waterSeqOn) {
      digitalWrite(redLEDPin, LOW);
      digitalWrite(yellowLEDPin, LOW);
      digitalWrite(greenLEDPin, HIGH);
      delay(500);
    } else if (scaleEmptyingOn) {
      digitalWrite(redLEDPin, HIGH);
      digitalWrite(yellowLEDPin, HIGH);
      digitalWrite(greenLEDPin, HIGH);
      delay(500);
    } else {
      digitalWrite(redLEDPin, LOW);
      digitalWrite(yellowLEDPin, LOW);
      digitalWrite(greenLEDPin, LOW);
      delay(500);
    }


    // ################## REFERENCE CODE #####################
    // Write an Int number on the database path test/int
    // if (Firebase.RTDB.setInt(&fbdo, "test/int", count)){
    //   Serial.println("PASSED");
    //   Serial.println("PATH: " + fbdo.dataPath());
    //   Serial.println("TYPE: " + fbdo.dataType());
    // }
    // else {
    //   Serial.println("FAILED");
    //   Serial.println("REASON: " + fbdo.errorReason());
    // }
    // count++;
    
    // Write an Float number on the database path test/float
    // if (Firebase.RTDB.setFloat(&fbdo, "test/float", 0.01 + random(0,100))){
    //   Serial.println("PASSED");
    //   Serial.println("PATH: " + fbdo.dataPath());
    //   Serial.println("TYPE: " + fbdo.dataType());
    // }
    // else {
    //   Serial.println("FAILED");
    //   Serial.println("REASON: " + fbdo.errorReason());
    // }

    // Read an Int from the realtime database
    // if (Firebase.RTDB.getInt(&fbdo, "test/int")) {
    //   if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_integer) {
    //     test_int = fbdo.to<int>();
    //     Serial.println("this is the value of test_int: ");
    //     Serial.println(test_int);
    //   }
    // }

    // Write an Int number to the realtime database
    //Firebase.RTDB.setInt(&fbdo, "test/int", test_int);
    // Write a bool value to the realtime database
    //Firebase.RTDB.setBool(&fbdo, "test/bool", cementSeqOn);
  }
}