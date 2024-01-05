addEventListener('resize', (event) => {
  let display_screen_width = (document.getElementById(
    'display_screen_width'
  ).innerText = window.innerWidth);
});

// silo capacity specs
let cement_capacity = 15000;
let agg_4_capacity = 15000;
let agg_8_capacity = 15000;
let agg_16_capacity = 15000;
let agg_32_capacity = 15000;
let water_capacity = 15000;

// silo current states
let cement_current = 3000;
let agg_4_current = 5550;
let agg_8_current = 800;
let agg_16_current = 12000;
let agg_32_current = 7770;
let water_current = 13000;

// measuring scale current stats
let cement_scale = 0;
let agg_4_scale = 0;
let agg_8_scale = 0;
let agg_16_scale = 0;
let agg_32_scale = 0;
let water_scale = 0;
let total_scale =
  cement_scale +
  agg_4_scale +
  agg_8_scale +
  agg_16_scale +
  agg_32_scale +
  water_scale;

// measuring scale recipe stats
let cement_recipe = 0;
let agg_4_recipe = 0;
let agg_8_recipe = 0;
let agg_16_recipe = 0;
let agg_32_recipe = 0;
let water_recipe = 0;

// concrete grade M15 recipe
let cement_M15 = 280;
let agg_4_M15 = 624;
let agg_8_M15 = 351;
let agg_16_M15 = 429;
let agg_32_M15 = 546;
let water_M15 = 175;
let concrete_weight_M15 =
  cement_M15 + agg_4_M15 + agg_8_M15 + agg_16_M15 + agg_32_M15 + water_M15;

// sequence is running?
let sequenceOn = false;

// default concrete amount in cubic meters
let cubicMeterAmount = 1;

// catch button commands
let startButton = document.getElementById('startButton');
let endBUtton = document.getElementById('endButton');

// scale values
document.getElementById('cement_scale').innerText = cement_scale;
document.getElementById('agg_4_scale').innerText = agg_4_scale;
document.getElementById('agg_8_scale').innerText = agg_8_scale;
document.getElementById('agg_16_scale').innerText = agg_16_scale;
document.getElementById('agg_32_scale').innerText = agg_32_scale;
document.getElementById('water_scale').innerText = water_scale;
document.getElementById('total_scale').innerText = total_scale;

// default recipe values
document.getElementById('cement_recipe').innerText = cement_recipe;
document.getElementById('agg_4_M15').innerText = agg_4_M15;
document.getElementById('agg_8_M15').innerText = agg_8_M15;
document.getElementById('agg_16_M15').innerText = agg_16_M15;
document.getElementById('agg_32_M15').innerText = agg_32_M15;
document.getElementById('water_M15').innerText = water_M15;
document.getElementById('concrete_weight_M15').innerText = 2405;

// calculated values based on desired cubic meter count
let req_cement = document.getElementById('cement_M15');

// M15 recipe
document.addEventListener('keyup', () => {
  // get desired cubic meter number from input field
  cubicMeterAmount = document.getElementById('concrete_cube').value;

  // change values of ingredients to reflect desired concrete amount

  req_cement.innerText = Math.floor(280 * cubicMeterAmount || 280);
  let req_agg_4 = (document.getElementById('agg_4_M15').innerText =
    Math.floor(620 * cubicMeterAmount) || 620);
  let req_agg_8 = (document.getElementById('agg_8_M15').innerText =
    Math.floor(350 * cubicMeterAmount) || 350);
  let req_agg16 = (document.getElementById('agg_16_M15').innerText =
    Math.floor(430 * cubicMeterAmount) || 430);
  let req_agg32 = (document.getElementById('agg_32_M15').innerText =
    Math.floor(550 * cubicMeterAmount) || 550);
  let req_water = (document.getElementById('water_M15').innerText =
    Math.floor(180 * cubicMeterAmount) || 180);
  let req_concrete_Weight = (document.getElementById(
    'concrete_weight_M15'
  ).innerText = Math.floor(2410 * cubicMeterAmount) || 2410);
});

// SILOS
// display gauge percentages cement
document.getElementById('cement_gauge_silo').style.width =
  (cement_current / cement_capacity) * 100 + '%';
document.getElementById('cement_current').innerHTML = cement_current;
document.getElementById('cement-cap').innerHTML = cement_capacity;

// display gauge percentages agregat 0-4
document.getElementById('agg_4_gauge').style.width =
  (agg_4_current / agg_4_capacity) * 100 + '%';
document.getElementById('agg_4_current').innerHTML = agg_4_current;
document.getElementById('agg_4_capacity').innerHTML = agg_4_capacity;

// display gauge percentages agregat 4-8
document.getElementById('agg_8_gauge').style.width =
  (agg_8_current / agg_8_capacity) * 100 + '%';
document.getElementById('agg_8_current').innerHTML = agg_8_current;
document.getElementById('agg_8_capacity').innerHTML = agg_8_capacity;

// display gauge percentages agregat 8-16
document.getElementById('agg_16_gauge').style.width =
  (agg_16_current / agg_16_capacity) * 100 + '%';
document.getElementById('agg_16_current').innerHTML = agg_16_current;
document.getElementById('agg_16_capacity').innerHTML = agg_16_capacity;

// display gauge percentages agregat 16-32
document.getElementById('agg_32_gauge').style.width =
  (agg_32_current / agg_32_capacity) * 100 + '%';
document.getElementById('agg_32_current').innerHTML = agg_32_current;
document.getElementById('agg_32_capacity').innerHTML = agg_32_capacity;

// display gauge percentages voda
document.getElementById('water_gauge').style.width =
  (water_current / water_capacity) * 100 + '%';
document.getElementById('water_current').innerHTML = water_current;
document.getElementById('water_capacity').innerHTML = water_capacity;

// SCALE
// M15 scale gauge value
document.getElementById('cement_gauge_scale').style.width =
  (cement_scale / req_cement) * 100 + '%';

// toggle main sequence execution
startButton.addEventListener('click', () => {
  if (sequenceOn == false) {
    sequenceOn = true;
    console.log('main sequence is on, value: ' + sequenceOn);
  }
});
endBUtton.addEventListener('click', () => {
  if (sequenceOn == true) {
    sequenceOn = false;
    console.log('main sequence is off, value: ' + sequenceOn);
  }
});

// main sequence function
setInterval(() => {
  if (sequenceOn) {
    if (cement_current > 0) {
      // remove from silo
      cement_current -= 10;
      document.getElementById('cement_current').innerText = cement_current;
      document.getElementById('cement-gauge').style.width =
        (cement_current / cement_capacity) * 100 + '%';
      // add to measuring scale
      cement_scale += 10;
      document.getElementById('cement_scale').innerText = cement_scale;
    } else {
      sequenceOn = false;
    }
  }
}, 100);

let btn_M15 = document.getElementById('btn_M15');

btn_M15.addEventListener('click', (e) => {
  document.getElementsByClassName('con-grade-btn');
  btn_M15.classList.add('on');
});
