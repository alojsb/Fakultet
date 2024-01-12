// Database Paths
var refillOnPath = 'concrete/refillOn';
var cementSeqOnPath = 'concrete/cementSeqOn';
var aggregateSeqOnPath = 'concrete/aggregateSeqOn';
var waterSeqOnPath = 'concrete/waterSeqOn';
var scaleEmptyingOnPath = 'concrete/scaleEmptyingOn';

// Get a database reference
const db_refillOn = database.ref(refillOnPath);
const db_cementSeqOn = database.ref(cementSeqOnPath);
const db_aggregateSeqOn = database.ref(aggregateSeqOnPath);
const db_waterSeqOn = database.ref(waterSeqOnPath);
const db_scaleEmptyingOn = database.ref(scaleEmptyingOnPath);

// Variables to save database current values
var refillOnReading;
var cementSeqOnReading;
var aggregateSeqOnReading;
var waterSeqOnReading;
var scaleEmptyingOnReading;

// Attach an asynchronous callback to read the data
db_refillOn.on(
  'value',
  (snapshot) => {
    refillOnReading = snapshot.val();
    console.log(refillOnReading);
    document.getElementById('reading-refillOn').innerHTML = refillOnReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

db_cementSeqOn.on(
  'value',
  (snapshot) => {
    cementSeqOnReading = snapshot.val();
    console.log(cementSeqOnReading);
    document.getElementById('reading-cementSeqOn').innerHTML =
      cementSeqOnReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

db_aggregateSeqOn.on(
  'value',
  (snapshot) => {
    aggregateSeqOnReading = snapshot.val();
    console.log(aggregateSeqOnReading);
    document.getElementById('reading-aggregateSeqOn').innerHTML =
      aggregateSeqOnReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

db_waterSeqOn.on(
  'value',
  (snapshot) => {
    waterSeqOnReading = snapshot.val();
    console.log(waterSeqOnReading);
    document.getElementById('reading-waterSeqOn').innerHTML = waterSeqOnReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

db_scaleEmptyingOn.on(
  'value',
  (snapshot) => {
    scaleEmptyingOnReading = snapshot.val();
    console.log(scaleEmptyingOnReading);
    document.getElementById('reading-scaleEmptyingOn').innerHTML =
      scaleEmptyingOnReading;
  },
  (errorObject) => {
    console.log('The read failed: ' + errorObject.name);
  }
);

// toggle bool values
function toggleRefill(path) {
  firebase.database().ref(path).set(!refillOnReading);
}

function toggleCementSequence(path) {
  firebase.database().ref(path).set(!cementSeqOnReading);
}

function toggleAggregateSequence(path) {
  firebase.database().ref(path).set(!aggregateSeqOnReading);
}

function toggleWaterSequence(path) {
  firebase.database().ref(path).set(!waterSeqOnReading);
}

function toggleScaleEmptying(path) {
  firebase.database().ref(path).set(!scaleEmptyingOnReading);
}
