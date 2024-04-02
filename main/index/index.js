const airvistaTouresShowBtn = document.getElementById('airvista-toures-show-btn');
const toureBlock4 = document.getElementById('toure4');
const toureBlock5 = document.getElementById('toure5');
const toureBlock6 = document.getElementById('toure6');

airvistaTouresShowBtn.addEventListener('click', changeColorButton);

function changeColorButton()
{
    setTimeout(showAllToures, 500)
    airvistaTouresShowBtn.style.backgroundColor = "#4fabcc";
}

function showAllToures()
{
    airvistaTouresShowBtn.style.display = "none";
    toureBlock4.style.display = "block";
    toureBlock5.style.display = "block";
    toureBlock6.style.display = "block";
}