// Database Paths
var dataFloatPath = 'test/float';
var dataIntPath = 'test/int';
var dataBoolPath = 'test/bool';

// Get a database reference
const databaseFloat = database.ref(dataFloatPath);
const databaseInt = database.ref(dataIntPath);
const databaseBool = database.ref(dataBoolPath);

// Variables to save database current values
var floatReading;
var intReading;
var boolReading;

// Attach an asynchronous callback to read the data
databaseFloat.on(
  'value',
  (snapshot) => {
    floatReading = snapshot.val();
    console.log(floatReading);
    document.getElementById('reading-float').innerHTML = floatReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

databaseInt.on(
  'value',
  (snapshot) => {
    intReading = snapshot.val();
    console.log(intReading);
    document.getElementById('reading-int').innerHTML = intReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

databaseBool.on(
  'value',
  (snapshot) => {
    boolReading = snapshot.val();
    console.log(boolReading);
    document.getElementById('reading-bool').innerHTML = boolReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

function toggleBoolValue(path) {
  firebase.database().ref(path).set(!boolReading);
}
