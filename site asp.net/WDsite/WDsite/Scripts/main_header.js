const headerFlightBtn = document.getElementById('header-flight-btn');
const headerReservationBtn = document.getElementById('header-reservation-btn');
const headerRegistrationBtn = document.getElementById('header-registration-btn');
const headerStatustBtn = document.getElementById('header-status-btn');

const withRadio = document.getElementById('radio-with-back');
const withoutRadio = document.getElementById('radio-without-back');
const multyRadio = document.getElementById('radio-multy');

const headerStatusRouteBtn = document.getElementById('header-status-route-btn');
const headerStatusNumberBtn = document.getElementById('header-status-number-btn');

const withDiv = document.getElementById('with-back-div');
const withoutDiv = document.getElementById('without-back-div');
const multyDiv = document.getElementById('multy-div');

const flightDiv = document.getElementById('header-flight-div');
const reservationDiv = document.getElementById('header-reservation-div');
const registrationDiv = document.getElementById('header-registration-div');
const statustDiv = document.getElementById('header-status-div');

const statusRoutetDiv = document.getElementById('header-status-route-div');
const statusNumbertDiv = document.getElementById('header-status-number-div');

withRadio.addEventListener('click', activeWithRadio);
withoutRadio.addEventListener('click', activeWithoutRadio);
multyRadio.addEventListener('click', activeMultyRadio);

headerFlightBtn.addEventListener('click', activeFlightsBtn);
headerReservationBtn.addEventListener('click', activeReservationBtn);
headerRegistrationBtn.addEventListener('click', activeRegistrationBtn);
headerStatustBtn.addEventListener('click', activeStatusBtn);

headerStatusRouteBtn.addEventListener('click', activeStatusRoute);
headerStatusNumberBtn.addEventListener('click', activeStatusNumber);

function removeAllActiveBtn() {
    headerFlightBtn.classList.remove('activeflights');
    headerReservationBtn.classList.remove('activeflights');
    headerRegistrationBtn.classList.remove('activeflights');
    headerStatustBtn.classList.remove('activeflights');
}

function hideAllBlocks() {
    flightDiv.style.display = "none";
    reservationDiv.style.display = "none";
    registrationDiv.style.display = "none";
    statustDiv.style.display = "none";
}

function hideAllRadioBlocks() {
    withRadio.classList.remove('activeradio');
    withoutRadio.classList.remove('activeradio');
    multyRadio.classList.remove('activeradio');
    withDiv.style.display = "none";
    withoutDiv.style.display = "none";
    multyDiv.style.display = "none";
}

function activeWithRadio() {
    hideAllRadioBlocks()
    withRadio.classList.add('activeradio');
    withDiv.style.display = "flex";
}

function activeWithoutRadio() {
    hideAllRadioBlocks()
    withoutRadio.classList.add('activeradio');
    withoutDiv.style.display = "flex";
}

function activeMultyRadio() {
    hideAllRadioBlocks()
    multyRadio.classList.add('activeradio');
    multyDiv.style.display = "flex";
}

function activeFlightsBtn() {
    removeAllActiveBtn();
    hideAllBlocks();
    headerFlightBtn.classList.add('activeflights');
    flightDiv.style.display = "block";
}

function activeReservationBtn() {
    removeAllActiveBtn();
    hideAllBlocks();
    headerReservationBtn.classList.add('activeflights');
    reservationDiv.style.display = "flex";
}

function activeRegistrationBtn() {
    removeAllActiveBtn();
    hideAllBlocks();
    headerRegistrationBtn.classList.add('activeflights');
    registrationDiv.style.display = "block";
}

function activeStatusBtn() {
    removeAllActiveBtn();
    hideAllBlocks();
    headerStatustBtn.classList.add('activeflights');
    statustDiv.style.display = "block";
}

function hideAllStatusDiv() {
    headerStatusRouteBtn.classList.remove('activestatus');
    headerStatusNumberBtn.classList.remove('activestatus');
    statusRoutetDiv.style.display = "none";
    statusNumbertDiv.style.display = "none";
}

function activeStatusRoute() {
    hideAllStatusDiv();
    headerStatusRouteBtn.classList.add('activestatus');
    statusRoutetDiv.style.display = "flex";
}

function activeStatusNumber() {
    hideAllStatusDiv();
    headerStatusNumberBtn.classList.add('activestatus');
    statusNumbertDiv.style.display = "flex";
}