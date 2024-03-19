// Get the buttons by their IDs
const locationBtn = document.getElementById('location-btn');
const ticketNumberBtn = document.getElementById('ticket-number-btn');

// Function to remove active class from all buttons
function deactivateAllButtons() {
  locationBtn.classList.remove('active');
  ticketNumberBtn.classList.remove('active');
}

// Function to activate a button
function activateButton(btn) {
  deactivateAllButtons();
  btn.classList.add('active');
}

// Add click event listener to the location button
locationBtn.addEventListener('click', function() {
  activateButton(locationBtn);
});

// Add click event listener to the ticket number button
ticketNumberBtn.addEventListener('click', function() {
  activateButton(ticketNumberBtn);
});