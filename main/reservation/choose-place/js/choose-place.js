// let activeDivId = null;

// function toggleActive(id) {
//     const div = document.getElementById(id);

//     // Якщо клікнули на активний блок, то знімаємо стиль актив
//     if (activeDivId === id) {
//         div.classList.remove('active');
//         activeDivId = null;
//     } else {
//         // Знімаємо стиль із попереднього активного блоку, якщо такий є
//         if (activeDivId) {
//             const activeDiv = document.getElementById(activeDivId);
//             activeDiv.classList.remove('active');
//         }

//         // Додаємо стиль до поточного блоку та оновлюємо активний id
//         div.classList.add('active');
//         activeDivId = id;
//     }
// }


let selectedAreas = {};

function selectTicket(ticket) {
    const ticketNumber = ticket.getAttribute('data-ticket');
    const ticketPrice = ticket.getAttribute('data-price');


    // Remove 'selected' class from all tickets
    const tickets = document.querySelectorAll('.ticket');
    tickets.forEach(t => t.classList.remove('selected'));

    // Add 'selected' class to the clicked ticket
    ticket.classList.add('selected');

    // Update the ticket information in the selected areas
    Object.keys(selectedAreas).forEach(area => {
        if (selectedAreas[area]) {
            document.getElementById(`ticketName${area}`).innerText = `${ticketNumber}`;
            document.getElementById(`ticketPrice${area}`).innerText = `€ ${ticketPrice}`;
        }
    });
}

function toggleArea(area) {
    const areaElement = document.getElementById(`area${area}`);
    if (areaElement.classList.contains('active')) {
        // Area is already active, make it inactive
        areaElement.classList.remove('active');
        selectedAreas[area] = false;
    } else {
        // Area is not active, make it active
        areaElement.classList.add('active');
        selectedAreas[area] = true;
    }
}