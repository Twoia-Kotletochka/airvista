document.addEventListener("DOMContentLoaded", function () {
    const dropdowns = document.querySelectorAll(".custom-dropdown");

    dropdowns.forEach(dropdown => {
        const selectedOption = dropdown.querySelector(".selected-option");
        const selectedValueDisplay = document.createElement("div");
        selectedValueDisplay.classList.add("selected-value");
        selectedOption.appendChild(selectedValueDisplay);
        const optionsList = dropdown.querySelector(".options");
        const text = dropdown.querySelector(".start-text");

        selectedOption.addEventListener("click", function () {
            optionsList.style.display = optionsList.style.display === "block" ? "none" : "block";
        });

        optionsList.addEventListener("click", function (event) {
            if (event.target.tagName === "LI") {
                const selectedValue = event.target.firstChild.innerText;
                selectedValueDisplay.textContent = selectedValue;
                optionsList.style.display = "none";
                text.style.display = "none";
            }
        });

        document.addEventListener("click", function (event) {
            if (!dropdown.contains(event.target)) {
                optionsList.style.display = "none";
            }
        });
    });
});

const dropdowns2 = document.querySelectorAll(".custom-dropdown2");

dropdowns2.forEach(dropdown => {
    const selectedOption = dropdown.querySelector(".selected-option2");
    const selectedValueDisplay = document.createElement("div");
    selectedValueDisplay.classList.add("selected-value2");
    selectedOption.appendChild(selectedValueDisplay);
    const optionsList = dropdown.querySelector(".options2");

    selectedOption.addEventListener("click", function () {
        optionsList.style.display = optionsList.style.display === "block" ? "none" : "block";
    });

    optionsList.addEventListener("click", function (event) {
        if (event.target.tagName === "LI") {
            const selectedValue = event.target.textContent;
            selectedValueDisplay.textContent = selectedValue;
            optionsList.style.display = "none";
        }
    });

    document.addEventListener("click", function (event) {
        if (!dropdown.contains(event.target)) {
            optionsList.style.display = "none";
        }
    });
});

function submitForm(form) {
    var textFrom = document.getElementById("div_country_from").innerText;
    var textTo = document.getElementById("div_country_to").innerText;
    document.getElementById("input_country_from").value = textFrom;
    document.getElementById("input_country_to").value = textTo;
    var textFrom = document.getElementById("div_country_from1").innerText;
    var textTo = document.getElementById("div_country_to1").innerText;
    document.getElementById("input_country_from1").value = textFrom;
    document.getElementById("input_country_to1").value = textTo;
    document.getElementById(form).submit();
}

