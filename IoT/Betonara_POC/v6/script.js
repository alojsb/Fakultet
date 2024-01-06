// screen width display
document.getElementById('display_screen_width').innerText = window.innerWidth;
addEventListener('resize', (event) => {
  document.getElementById('display_screen_width').innerText = window.innerWidth;
});

// will be defined in firebase reatime database
// ############## SILO STATS #############
let cement_current = 10000;
let cement_capacity = 15000;
let agg_4_current = 10000;
let agg_4_capacity = 15000;
let water_current = 6333;
let water_capacity = 15000;

// ############## SILO GAUGE DISPLAY #############
// cement
document.getElementById('cement_current').innerText = cement_current;
document.getElementById('cement_capacity').innerText = cement_capacity;
document.getElementById('cement_gauge_silo').style.width =
  Math.floor((cement_current / cement_capacity) * 100) + '%';
// agg_4
document.getElementById('agg_4_current').innerText = agg_4_current;
document.getElementById('agg_4_capacity').innerText = agg_4_capacity;
document.getElementById('agg_4_gauge_silo').style.width =
  Math.floor((agg_4_current / agg_4_capacity) * 100) + '%';
// water
document.getElementById('water_current').innerText = water_current;
document.getElementById('water_capacity').innerText = water_capacity;
document.getElementById('water_gauge_silo').style.width =
  Math.floor((water_current / water_capacity) * 100) + '%';

// ############## MAIN CONTROL #############
// sequence is running?
let sequenceOn = false;
// default concrete amount in cubic meters
let cubicMeterAmount = 1;

// ############## RECIPE INITIAL VALUES #############
let cement_recipe = 280;
let agg_4_recipe = 1950;
let water_recipe = 180;
let total_recipe = cement_recipe + agg_4_recipe + water_recipe;

// ############## RECIPE CALCULATED VALUES #############
let req_cement = cement_recipe * cubicMeterAmount;
let req_agg_4 = agg_4_recipe * cubicMeterAmount;
let req_water = water_recipe * cubicMeterAmount;
let req_total = total_recipe * cubicMeterAmount;

// ############## RECIPE DISPLAY #############
document.getElementById('cement_recipe').innerText = req_cement;
document.getElementById('agg_4_recipe').innerText = req_agg_4;
document.getElementById('water_recipe').innerText = req_water;
document.getElementById('concrete_weight_recipe').innerText = req_total;

// ############## SCALE STATS #############
let cement_scale = 50;
let agg_4_scale = 88;
let water_scale = 78;
let total_scale = cement_scale + agg_4_scale + water_scale;

// ############## SCALE DISPLAY #############
document.getElementById('cement_scale').innerText = cement_scale;
document.getElementById('agg_4_scale').innerText = agg_4_scale;
document.getElementById('water_scale').innerText = water_scale;
document.getElementById('total_scale').innerText = total_scale;

// ############## SCALE GAUGE DISPLAY #############
document.getElementById('cement_gauge_scale').style.width =
  Math.floor((cement_scale / req_cement) * 100) + '%';
document.getElementById('agg_4_gauge_scale').style.width =
  Math.floor((agg_4_scale / req_agg_4) * 100) + '%';
document.getElementById('water_gauge_scale').style.width =
  Math.floor((water_scale / req_water) * 100) + '%';
document.getElementById('total_gauge_scale').style.width =
  Math.floor((total_scale / req_total) * 100) + '%';

// recipe calculation
document.addEventListener('keyup', () => {
  // get desired cubic meter number from input field
  cubicMeterAmount = document.getElementById('concrete_cube').value;

  // refresh required recipe values
  req_cement = cement_recipe * cubicMeterAmount;
  req_agg_4 = agg_4_recipe * cubicMeterAmount;
  req_water = water_recipe * cubicMeterAmount;
  req_total = total_recipe * cubicMeterAmount;

  // change recipe values of ingredients to reflect desired concrete amount
  document.getElementById('cement_recipe').innerText = Math.floor(
    cement_recipe * cubicMeterAmount || cement_recipe
  );
  document.getElementById('agg_4_recipe').innerText =
    Math.floor(agg_4_recipe * cubicMeterAmount) || agg_4_recipe;
  document.getElementById('water_recipe').innerText =
    Math.floor(water_recipe * cubicMeterAmount) || water_recipe;
  document.getElementById('concrete_weight_recipe').innerText =
    Math.floor(total_recipe * cubicMeterAmount) || total_recipe;
  //change gauge indicators
  document.getElementById('cement_gauge_scale').style.width =
    Math.floor((cement_scale / req_cement) * 100) + '%';
  document.getElementById('agg_4_gauge_scale').style.width =
    Math.floor((agg_4_scale / req_agg_4) * 100) + '%';
  document.getElementById('water_gauge_scale').style.width =
    Math.floor((water_scale / req_water) * 100) + '%';
  document.getElementById('total_gauge_scale').style.width =
    Math.floor((total_scale / req_total) * 100) + '%';
});
