// screen width display
// document.getElementById('display_screen_width').innerText = window.innerWidth;
// addEventListener('resize', (event) => {
//   document.getElementById('display_screen_width').innerText = window.innerWidth;
// });

// will be defined in firebase reatime database
// ############## SILO STATS #############
let cement_current = 5000;
let cement_capacity = 5000;
let agg_4_current = 30000;
let agg_4_capacity = 30000;
let water_current = 3000;
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
// pouring sequence is running?
let sequenceOn = false;
// refill is running?
let refillOn = false;
// scale is empyting?
let scaleEmptyingOn = false;
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
let agg_4_scale = 25000;
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
  if (
    cubicMeterAmount > 1 &&
    sequenceOn == false &&
    refillOn == false &&
    scaleEmptyingOn == false
  ) {
    if (
      cement_scale <= cement_recipe * (cubicMeterAmount - 1) &&
      agg_4_scale <= agg_4_recipe * (cubicMeterAmount - 1) &&
      water_scale <= water_recipe * (cubicMeterAmount - 1)
    ) {
      cubicMeterAmount -= 1;
      document.getElementById('cubic_amount').innerText = cubicMeterAmount;
      updateRecipeValues(cubicMeterAmount);
    } else {
      console.log(
        'decreasing the cubic volume amount not allowed until the scale is emptied'
      );
    }
  } else {
    if (
      cubicMeterAmount == 1 &&
      sequenceOn == false &&
      refillOn == false &&
      scaleEmptyingOn == false
    ) {
      console.log('minimum reached');
    } else {
      console.log(
        'cannot change this value while one of these processes is active: refill, main pouring sequence, emptying of the scale'
      );
    }
  }
});

cubic_plus.addEventListener('click', () => {
  if (
    cubicMeterAmount < 15 &&
    sequenceOn == false &&
    refillOn == false &&
    scaleEmptyingOn == false
  ) {
    cubicMeterAmount += 1;
    document.getElementById('cubic_amount').innerText = cubicMeterAmount;
    updateRecipeValues(cubicMeterAmount);
  } else {
    if (
      cubicMeterAmount == 15 &&
      sequenceOn == false &&
      refillOn == false &&
      scaleEmptyingOn == false
    ) {
      console.log('maximum reached');
    } else {
      console.log(
        'cannot change this value while one of these processes is active: refill, main pouring sequence, emptying of the scale'
      );
    }
  }
});

// catch button commands
let startButton = document.getElementById('startButton');
let endBUtton = document.getElementById('endButton');

function toggleMainSequence(status) {
  if (status == false) {
    sequenceOn = true;
    document.getElementById('process_status').innerText = 'Aktivan';
    console.log('pouring sequence on');
  } else {
    sequenceOn = false;
    document.getElementById('process_status').innerText = 'Isključen';
    console.log('pouring sequence off');
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

function checkSupplies() {
  return (
    cement_current >= req_cement - cement_scale &&
    agg_4_current >= req_agg_4 - agg_4_scale &&
    water_current >= req_water - water_scale
  );
}

// main sequence function
setInterval(() => {
  if (sequenceOn) {
    if (checkSupplies()) {
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
      } else if (agg_4_scale < req_agg_4) {
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
        // filled up from all silos
        toggleMainSequence(sequenceOn);
        console.log('filled up from all silos');
      }
    } else {
      // not enough supplies
      toggleMainSequence(sequenceOn);
      console.log('not enough supplies');
    }
  }
}, 100);

// pour concrete - empty scale
let pour_concrete_btn = document.getElementById('pour_concrete_btn');
let pourOut;

pour_concrete_btn.addEventListener('click', () => {
  if (sequenceOn == false && scaleEmptyingOn == false) {
    console.log('pouring concrete out of the scale');
    scaleEmptyingOn = true;
    pourOut = setInterval(() => {
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
        console.log('scale empty');
        clearInterval(pourOut);
        scaleEmptyingOn = false;
      }
    }, 100);
  }
});

let stop_concrete_btn = document.getElementById('stop_concrete_btn');

stop_concrete_btn.addEventListener('click', () => {
  if (scaleEmptyingOn == true) {
    clearInterval(pourOut);
    scaleEmptyingOn = false;
    console.log('pouring process stopped');
  }
});

// refill silos
let refill = document.getElementById('refill');

refill.addEventListener('click', () => {
  if (!sequenceOn) {
    console.log('refill sequence on');
    refillOn = true;
    let fillUpSilos = setInterval(() => {
      if (cement_current < cement_capacity) {
        // add to silo
        cement_current += 10;
        document.getElementById('cement_current').innerText = cement_current;
        document.getElementById('cement_gauge_silo').style.width =
          (cement_current / cement_capacity) * 100 + '%';
      } else if (agg_4_current < agg_4_capacity) {
        // remove from silo
        agg_4_current += 10;
        document.getElementById('agg_4_current').innerText = agg_4_current;
        document.getElementById('agg_4_gauge_silo').style.width =
          (agg_4_current / agg_4_capacity) * 100 + '%';
      } else if (water_current < water_capacity) {
        // remove from silo
        water_current += 10;
        document.getElementById('water_current').innerText = water_current;
        document.getElementById('water_gauge_silo').style.width =
          (water_current / water_capacity) * 100 + '%';
      } else {
        console.log('silos completely refilled');
        clearInterval(fillUpSilos);
        console.log('refill sequence off');
        refillOn = false;
      }
    }, 100);
  }
});
