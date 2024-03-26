const locationBtnOne = document.getElementById('one-btn');
const locationBtnTwo = document.getElementById('two-btn');
const locationBtnThree = document.getElementById('three-btn');

const btnflightsOne = document.getElementById('btn-flights-one');
const btnflightsTwo = document.getElementById('btn-flights-two');
const btnflightsThree = document.getElementById('btn-flights-three');
const btnflightsFour = document.getElementById('btn-flights-four');

function deactivateAllButtons() {
  locationBtnOne.classList.remove('active');
  locationBtnTwo.classList.remove('active');
  locationBtnThree.classList.remove('active');
}


function activateButton(btn) {
  deactivateAllButtons();
  btn.classList.add('active');
}


locationBtnThree.addEventListener('click', function () {
  activateButton(locationBtnThree);
});


locationBtnTwo.addEventListener('click', function () {
  activateButton(locationBtnTwo);

  // destination.style.display = 'none';
  // flightnumber.style.display = 'block';
});


locationBtnOne.addEventListener('click', function () {
  activateButton(locationBtnOne);

  // flightnumber.style.display = 'none';
  // destination.style.display = 'block';
});


function deactivateAllBtn() {
  btnflightsOne.classList.remove('activeflights');
  btnflightsTwo.classList.remove('activeflights');
  btnflightsThree.classList.remove('activeflights');
  btnflightsFour.classList.remove('activeflights');
}

function activateBtn(btn) {
  deactivateAllBtn();
  btn.classList.add('activeflights');
}

btnflightsOne.addEventListener('click', function () {
  activateBtn(btnflightsOne);
});

btnflightsTwo.addEventListener('click', function () {
  activateBtn(btnflightsTwo);
});

btnflightsThree.addEventListener('click', function () {
  activateBtn(btnflightsThree);
});

btnflightsFour.addEventListener('click', function () {
  activateBtn(btnflightsFour);
});