// screen width display
document.getElementById('display_screen_width').innerText = window.innerWidth;
addEventListener('resize', (event) => {
  document.getElementById('display_screen_width').innerText = window.innerWidth;
});

// will be defined in firebase reatime database
// ############## SILO STATS #############
let cement_current = 4000;
let cement_capacity = 5000;
let agg_4_current = 10000;
let agg_4_capacity = 15000;
let water_current = 2333;
let water_capacity = 3000;

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
let agg_4_scale = 90;
let water_scale = 80;
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

// recipe re-calculation
// get desired cubic meter amount as parameter
function updateRecipeValues(cubics) {
  // refresh required recipe values
  req_cement = cement_recipe * cubics;
  req_agg_4 = agg_4_recipe * cubics;
  req_water = water_recipe * cubics;
  req_total = total_recipe * cubics;

  // change recipe values of ingredients to reflect desired concrete amount
  document.getElementById('cement_recipe').innerText = Math.floor(
    cement_recipe * cubics || cement_recipe
  );
  document.getElementById('agg_4_recipe').innerText =
    Math.floor(agg_4_recipe * cubics) || agg_4_recipe;
  document.getElementById('water_recipe').innerText =
    Math.floor(water_recipe * cubics) || water_recipe;
  document.getElementById('concrete_weight_recipe').innerText =
    Math.floor(total_recipe * cubics) || total_recipe;
  //change gauge indicators
  document.getElementById('cement_gauge_scale').style.width =
    Math.floor((cement_scale / req_cement) * 100) + '%';
  document.getElementById('agg_4_gauge_scale').style.width =
    Math.floor((agg_4_scale / req_agg_4) * 100) + '%';
  document.getElementById('water_gauge_scale').style.width =
    Math.floor((water_scale / req_water) * 100) + '%';
  document.getElementById('total_gauge_scale').style.width =
    Math.floor((total_scale / req_total) * 100) + '%';
}

// increase/decrease cubic meter count
let cubic_minus = document.getElementById('cubic_minus');
let cubic_plus = document.getElementById('cubic_plus');

cubic_minus.addEventListener('click', () => {
  console.log(cubicMeterAmount);
  if (cubicMeterAmount > 1) {
    cubicMeterAmount -= 1;
    document.getElementById('cubic_amount').innerText = cubicMeterAmount;
    updateRecipeValues(cubicMeterAmount);
  }
});

cubic_plus.addEventListener('click', () => {
  console.log(cubicMeterAmount);
  if (cubicMeterAmount < 15) {
    cubicMeterAmount += 1;
    document.getElementById('cubic_amount').innerText = cubicMeterAmount;
    updateRecipeValues(cubicMeterAmount);
  }
});

// catch button commands
let startButton = document.getElementById('startButton');
let endBUtton = document.getElementById('endButton');

function toggleMainSequence(status) {
  if (status == false) {
    sequenceOn = true;
    document.getElementById('process_status').innerText = 'Aktivan';
  } else {
    sequenceOn = false;
    document.getElementById('process_status').innerText = 'Isključen';
  }
}

// toggle main sequence execution
startButton.addEventListener('click', () => {
  if (sequenceOn == false) {
    toggleMainSequence(sequenceOn);
  }
});
endBUtton.addEventListener('click', () => {
  if (sequenceOn == true) {
    toggleMainSequence(sequenceOn);
  }
});

// main sequence function
setInterval(() => {
  if (sequenceOn) {
    if (cement_current > 0) {
      if (cement_scale < req_cement) {
        // remove from silo
        cement_current -= 10;
        document.getElementById('cement_current').innerText = cement_current;
        document.getElementById('cement_gauge_silo').style.width =
          (cement_current / cement_capacity) * 100 + '%';
        // add to measuring scale
        cement_scale += 10;
        document.getElementById('cement_scale').innerText = cement_scale;
        document.getElementById('cement_gauge_scale').style.width =
          Math.floor((cement_scale / req_cement) * 100) + '%';
        total_scale += 10;
        document.getElementById('total_scale').innerText = total_scale;
        document.getElementById('total_gauge_scale').style.width =
          Math.floor((total_scale / req_total) * 100) + '%';
      } else if (agg_4_current > 0) {
        if (agg_4_scale < req_agg_4) {
          // remove from silo
          agg_4_current -= 10;
          document.getElementById('agg_4_current').innerText = agg_4_current;
          document.getElementById('agg_4_gauge_silo').style.width =
            (agg_4_current / agg_4_capacity) * 100 + '%';
          // add to measuring scale
          agg_4_scale += 10;
          document.getElementById('agg_4_scale').innerText = agg_4_scale;
          document.getElementById('agg_4_gauge_scale').style.width =
            Math.floor((agg_4_scale / req_agg_4) * 100) + '%';
          total_scale += 10;
          document.getElementById('total_scale').innerText = total_scale;
          document.getElementById('total_gauge_scale').style.width =
            Math.floor((total_scale / req_total) * 100) + '%';
        } else if (water_scale < req_water) {
          // remove from silo
          water_current -= 10;
          document.getElementById('water_current').innerText = water_current;
          document.getElementById('water_gauge_silo').style.width =
            (water_current / water_capacity) * 100 + '%';
          // add to measuring scale
          water_scale += 10;
          document.getElementById('water_scale').innerText = water_scale;
          document.getElementById('water_gauge_scale').style.width =
            Math.floor((water_scale / req_water) * 100) + '%';
          total_scale += 10;
          document.getElementById('total_scale').innerText = total_scale;
          document.getElementById('total_gauge_scale').style.width =
            Math.floor((total_scale / req_total) * 100) + '%';
        } else {
          toggleMainSequence(sequenceOn);
        }
      } else {
        // sequenceOn = false;
        toggleMainSequence(sequenceOn);
      }
    } else {
      // sequenceOn = false;
      toggleMainSequence(sequenceOn);
    }
  }
}, 100);

// pour concrete - empty scale
let pour_concrete_btn = document.getElementById('pour_concrete_btn');

function pourConcrete() {
  let pourOut = setInterval(() => {
    if (cement_scale > 0) {
      cement_scale -= 10;
      document.getElementById('cement_scale').innerText = cement_scale;
      document.getElementById('cement_gauge_scale').style.width =
        Math.floor((cement_scale / req_cement) * 100) + '%';
      total_scale -= 10;
      document.getElementById('total_scale').innerText = total_scale;
      document.getElementById('total_gauge_scale').style.width =
        Math.floor((total_scale / req_total) * 100) + '%';
    } else if (agg_4_scale > 0) {
      agg_4_scale -= 10;
      document.getElementById('agg_4_scale').innerText = agg_4_scale;
      document.getElementById('agg_4_gauge_scale').style.width =
        Math.floor((agg_4_scale / req_agg_4) * 100) + '%';
      total_scale -= 10;
      document.getElementById('total_scale').innerText = total_scale;
      document.getElementById('total_gauge_scale').style.width =
        Math.floor((total_scale / req_total) * 100) + '%';
    } else if (water_scale > 0) {
      water_scale -= 10;
      document.getElementById('water_scale').innerText = water_scale;
      document.getElementById('water_gauge_scale').style.width =
        Math.floor((water_scale / req_water) * 100) + '%';
      total_scale -= 10;
      document.getElementById('total_scale').innerText = total_scale;
      document.getElementById('total_gauge_scale').style.width =
        Math.floor((total_scale / req_total) * 100) + '%';
    } else {
      clearInterval(pourOut);
    }
  }, 100);
}

pour_concrete_btn.addEventListener('click', () => {
  if (!sequenceOn) {
    pourConcrete();
  }
});
