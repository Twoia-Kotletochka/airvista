// Get the buttons by their IDs
const ticketNumberBtn = document.getElementById('ticket-number-btn');
const locationBtn = document.getElementById('location-btn');

const flightnumber = document.getElementById('flight-number'); //ticket-number-btn
const destination = document.getElementById('destination');

// Function to remove active class from all buttons
function deactivateAllButtons() {
  ticketNumberBtn.classList.remove('active');
  locationBtn.classList.remove('active');
}

// Function to activate a button
function activateButton(btn) {
  deactivateAllButtons();
  btn.classList.add('active');
}

// Add click event listener to the location button
locationBtn.addEventListener('click', function() {
  activateButton(locationBtn);
  destination.style.display = 'none';
  flightnumber.style.display = 'block';
});

// Add click event listener to the ticket number button
ticketNumberBtn.addEventListener('click', function() {
  activateButton(ticketNumberBtn);
  flightnumber.style.display = 'none';
  destination.style.display = 'block';
});
