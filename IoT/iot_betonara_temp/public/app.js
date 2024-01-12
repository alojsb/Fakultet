// Database Paths
var dataFloatPath = 'test/float';
var dataIntPath = 'test/int';
var dataBoolPath = 'test/bool';

var sequenceOnPath = 'concrete/sequenceOn';
var cement_currentPath = 'concrete/cement_current';

// Get a database reference
const databaseFloat = database.ref(dataFloatPath);
const databaseInt = database.ref(dataIntPath);
const databaseBool = database.ref(dataBoolPath);

const db_sequenceOn = database.ref(sequenceOnPath);
const db_cement_current = database.ref(cement_currentPath);

// Variables to save database current values
var floatReading;
var intReading;
var boolReading;

var sequenceOnReading;
var cement_currentReading;

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

db_sequenceOn.on(
  'value',
  (snapshot) => {
    sequenceOnReading = snapshot.val();
    console.log(sequenceOnReading);
    document.getElementById('reading-sequenceOn').innerHTML = sequenceOnReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

db_cement_current.on(
  'value',
  (snapshot) => {
    cement_currentReading = snapshot.val();
    console.log(cement_currentReading);
    document.getElementById('reading-cement_current').innerHTML =
      cement_currentReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

function toggleBoolValue(path) {
  firebase.database().ref(path).set(!boolReading);
}

function toggleMainSequence(path) {
  firebase.database().ref(path).set(!sequenceOnReading);
}
