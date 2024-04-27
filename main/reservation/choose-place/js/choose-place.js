let activeDivId = null;

function toggleActive(id) {
    const div = document.getElementById(id);

    // Якщо клікнули на активний блок, то знімаємо стиль актив
    if (activeDivId === id) {
        div.classList.remove('active');
        activeDivId = null;
    } else {
        // Знімаємо стиль із попереднього активного блоку, якщо такий є
        if (activeDivId) {
            const activeDiv = document.getElementById(activeDivId);
            activeDiv.classList.remove('active');
        }

        // Додаємо стиль до поточного блоку та оновлюємо активний id
        div.classList.add('active');
        activeDivId = id;
    }
}


let selectedArea = null;
let selectedTicket = null;

function selectTicket(ticket) {
    const ticketNumber = ticket.getAttribute('data-ticket');
    const ticketPrice = ticket.getAttribute('data-price');
    const ticketName = ticket.innerText;
    selectedTicket = ticket;

    if (selectedArea) {
        document.getElementById(`ticketName${selectedArea}`).innerText = `Выбран билет ${ticketNumber}: ${ticketName}`;
        document.getElementById(`ticketPrice${selectedArea}`).innerText = `Цена: ${ticketPrice} грн`;
        ticket.classList.add('selected');
    } else {
        alert('Выберите область для размещения номера билета');
    }
}

function selectArea(area) {
    if (selectedArea === area) {
        document.getElementById(`area${area}`).classList.remove('selected');
        document.getElementById(`ticketName${area}`).innerText = '';
        document.getElementById(`ticketPrice${area}`).innerText = '';
        selectedArea = null;
        if (selectedTicket) {
            selectedTicket.classList.remove('selected');
            selectedTicket = null;
        }
    } else {
        document.getElementById(`area${area}`).classList.add('selected');
        selectedArea = area;
        if (selectedTicket) {
            const ticketNumber = selectedTicket.getAttribute('data-ticket');
            const ticketName = selectedTicket.innerText;
            const ticketPrice = selectedTicket.getAttribute('data-price');
            document.getElementById(`ticketName${area}`).innerText = `Выбран билет ${ticketNumber}: ${ticketName}`;
            document.getElementById(`ticketPrice${area}`).innerText = `Цена: ${ticketPrice} грн`;
        }
    }
}