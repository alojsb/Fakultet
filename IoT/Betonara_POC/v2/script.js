// silo capacity specs
let cap_cement = 15000;
let cap_agg_4 = 15000;
let cap_agg_8 = 15000;
let cap_agg_16 = 15000;
let cap_agg_32 = 15000;
let cap_water = 15000;

// silo current states
let curr_cement = 9124;
let curr_agg_4 = 8888;
let curr_agg_8 = 5555;
let curr_agg_16 = 4444;
let curr_agg_32 = 7777;
let curr_water = 7777;

// gauge percentages
//let per_cement = (curr_cement / cap_cement) * 100;

// display gauge percentages
document.getElementById('gauge-cement').style.height =
  (curr_cement / cap_cement) * 100 + '%';

// tab functionality
function openCity(cityName) {
  var i;
  var x = document.getElementsByClassName('city');
  for (i = 0; i < x.length; i++) {
    x[i].style.display = 'none';
  }
  document.getElementById(cityName).style.display = 'block';
}
