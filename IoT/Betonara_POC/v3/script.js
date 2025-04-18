// silo capacity specs
let cement_capacity = 15000;
let agg_4_capacity = 15000;
let agg_8_capacity = 15000;
let agg_16_capacity = 15000;
let agg_32_capacity = 15000;
let water_capacity = 15000;

// silo current states
let cement_current = 1000;
let agg_4_current = 5550;
let agg_8_current = 800;
let agg_16_current = 12000;
let agg_32_current = 7770;
let water_current = 13000;

// measuring scale content stats
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

// sequence is running?
let sequenceOn = false;

// default concrete amount in cubic meters
let cubicMeterAmount = 1;

// catch button commands
let startButton = document.getElementById('startButton');
let endBUtton = document.getElementById('endButton');

// write to DOM ingredient amounts in the scale
document.getElementById('cement_scale').innerText = cement_scale;
document.getElementById('agg_4_scale').innerText = agg_4_scale;
document.getElementById('agg_8_scale').innerText = agg_8_scale;
document.getElementById('agg_16_scale').innerText = agg_16_scale;
document.getElementById('agg_32_scale').innerText = agg_32_scale;
document.getElementById('water_scale').innerText = water_scale;
document.getElementById('total_scale').innerText = total_scale;

// default M15 ingredient values
document.getElementById('cement_M15').innerText = 280;
document.getElementById('agg_4_M15').innerText = 624;
document.getElementById('agg_8_M15').innerText = 351;
document.getElementById('agg_16_M15').innerText = 429;
document.getElementById('agg_32_M15').innerText = 546;
document.getElementById('water_M15').innerText = 175;
document.getElementById('concrete_weight_M15').innerText = 2405;

// M15 recipe
document.addEventListener('keyup', () => {
  // get desired cubic meter number from input field
  cubicMeterAmount = document.getElementById('concrete_cube').value;

  // change values of ingredients to reflect desired concrete amount
  document.getElementById('cement_M15').innerText = Math.floor(
    280 * cubicMeterAmount || 280
  );
  document.getElementById('agg_4_M15').innerText =
    Math.floor(620 * cubicMeterAmount) || 620;
  document.getElementById('agg_8_M15').innerText =
    Math.floor(350 * cubicMeterAmount) || 350;
  document.getElementById('agg_16_M15').innerText =
    Math.floor(430 * cubicMeterAmount) || 430;
  document.getElementById('agg_32_M15').innerText =
    Math.floor(550 * cubicMeterAmount) || 550;
  document.getElementById('water_M15').innerText =
    Math.floor(180 * cubicMeterAmount) || 180;
  document.getElementById('concrete_weight_M15').innerText =
    Math.floor(2410 * cubicMeterAmount) || 2410;
});

// display gauge percentages cement
document.getElementById('cement-gauge').style.width =
  (cement_current / cement_capacity) * 100 + '%';
document.getElementById('cement_current').innerHTML = cement_current;
document.getElementById('cement-cap').innerHTML = cement_capacity;

// display gauge percentages agregat 0-4
document.getElementById('agg-4-gauge').style.width =
  (agg_4_current / agg_4_capacity) * 100 + '%';
document.getElementById('agg-4-amount').innerHTML = agg_4_current;
document.getElementById('agg-4-cap').innerHTML = agg_4_capacity;

// display gauge percentages agregat 4-8
document.getElementById('agg-8-gauge').style.width =
  (agg_8_current / agg_8_capacity) * 100 + '%';
document.getElementById('agg-8-amount').innerHTML = agg_8_current;
document.getElementById('agg-8-cap').innerHTML = agg_8_capacity;

// display gauge percentages agregat 8-16
document.getElementById('agg-16-gauge').style.width =
  (agg_16_current / agg_16_capacity) * 100 + '%';
document.getElementById('agg-16-amount').innerHTML = agg_16_current;
document.getElementById('agg-16-cap').innerHTML = agg_16_capacity;

// display gauge percentages agregat 16-32
document.getElementById('agg-32-gauge').style.width =
  (agg_32_current / agg_32_capacity) * 100 + '%';
document.getElementById('agg-32-amount').innerHTML = agg_32_current;
document.getElementById('agg-32-cap').innerHTML = agg_32_capacity;

// display gauge percentages voda
document.getElementById('water-gauge').style.width =
  (water_current / water_capacity) * 100 + '%';
document.getElementById('water-amount').innerHTML = water_current;
document.getElementById('water-cap').innerHTML = water_capacity;

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

// tab funcionality
function openRecipe(evt, recipe) {
  var i, tabcontent, tablinks;
  tabcontent = document.getElementsByClassName('tabcontent');
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = 'none';
  }
  tablinks = document.getElementsByClassName('tablinks');
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace(' active', '');
  }
  document.getElementById(recipe).style.display = 'block';
  evt.currentTarget.className += ' active';
}
