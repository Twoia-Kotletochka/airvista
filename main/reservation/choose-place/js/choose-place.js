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