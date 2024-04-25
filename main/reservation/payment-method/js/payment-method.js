const cardBtn = document.getElementById('card-btn');
const paypalBtn = document.getElementById('paypal-btn');
const privatBtn = document.getElementById('privat-btn');

cardBtn.addEventListener('click', () => {
    cardBtn.classList.add('active');
    paypalBtn.classList.remove('active');
    privatBtn.classList.remove('active');
});

paypalBtn.addEventListener('click', () => {
    cardBtn.classList.remove('active');
    paypalBtn.classList.add('active');
    privatBtn.classList.remove('active');
});

privatBtn.addEventListener('click', () => {
    cardBtn.classList.remove('active');
    paypalBtn.classList.remove('active');
    privatBtn.classList.add('active');
});