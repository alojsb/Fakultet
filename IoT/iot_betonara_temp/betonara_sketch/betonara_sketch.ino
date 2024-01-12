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

unsigned long sendDataPrevMillis = 0;
bool signupOK = false;

int cement_capacity;
int cement_current;
bool sequenceOn;

bool test_bool;

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
}

void loop(){
  if (Firebase.ready() && signupOK && (millis() - sendDataPrevMillis > 2000 || sendDataPrevMillis == 0)){
    sendDataPrevMillis = millis();

    Serial.println("------------- print this or else... --------------");

    // Read an Int from the realtime database
    if (Firebase.RTDB.getInt(&fbdo, "concrete/cement_capacity")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_integer) {
        cement_capacity = fbdo.to<int>();
        // Serial.println("this is the value of cement_capacity: ");
        // Serial.println(cement_capacity);
      }
    }
    // Read an Int from the realtime database
    if (Firebase.RTDB.getInt(&fbdo, "concrete/cement_current")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_integer) {
        cement_current = fbdo.to<int>();
        // Serial.println("this is the value of cement_capacity: ");
        // Serial.println(cement_current);
      }
    }
    // Read a bool value from the realtime database
    if (Firebase.RTDB.getBool(&fbdo, "/concrete/sequenceOn")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_boolean) {
        sequenceOn = fbdo.to<bool>();
        // Serial.println("this is the value of sequenceOn: ");
        // Serial.println(sequenceOn);
      }
    }
    // read bool II try
    if (Firebase.RTDB.getBool(&fbdo, "/test/bool")) {
      if (fbdo.dataTypeEnum() == firebase_rtdb_data_type_boolean) {
        test_bool = fbdo.to<bool>();
        // Serial.println("this is the value of test_bool: ");
        // Serial.println(test_bool);
      }
    }
    // increase cement current if sequenceOn is true
    if (sequenceOn && cement_current < cement_capacity)
    {
      Firebase.RTDB.setInt(&fbdo, "concrete/cement_current", cement_current + 10);
    }
    

    // Write an Int number to the realtime database
    Firebase.RTDB.setInt(&fbdo, "concrete/cement_capacity", cement_capacity);
    // Write a bool value to the realtime database
    Firebase.RTDB.setBool(&fbdo, "test/bool", sequenceOn);

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

  }
}