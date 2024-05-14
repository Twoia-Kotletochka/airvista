document.getElementById('currencyToggle').addEventListener('click', function () {
    var dropdownMenu = document.querySelector('.dropdown-menu1');
    dropdownMenu.classList.toggle('active');
});


var currencyItems = document.querySelectorAll('.dropdown-menu1 .currency-box');
currencyItems.forEach(function (item) {
    item.addEventListener('click', function (event) {
        event.preventDefault();
        var currencyText = this.querySelector('span').textContent;
        var currencyToggle = document.getElementById('currencyToggle');
        currencyToggle.textContent = currencyText;

        $.ajax({
            type: 'POST',
            url: '/home/SaveCurrencyText',
            data: JSON.stringify({ currencyText: currencyText }),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (response) {
                console.log('Данные успешно отправлены на сервер.');
            },
            error: function (xhr, status, error) {
                console.error('Произошла ошибка при отправке данных на сервер.');
            }
        });



        var dropdownMenu = document.querySelector('.dropdown-menu1');
        dropdownMenu.classList.remove('active');
    });
});