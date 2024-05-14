//Увійти
document.getElementById("showForm").addEventListener("click", function () {
    document.getElementById("myForm").style.display = "block";
    document.querySelector(".overlay").style.display = "block";
    setTimeout(function () {
        document.getElementById("myForm").style.opacity = 1;
        document.getElementById("myForm").style.transform = "translate(-50%, 44%)";
    }, 100);
    document.body.style.overflow = 'hidden'; // блокировка скролла
});

document.getElementById("closeForm").addEventListener("click", function () {
    document.getElementById("myForm").style.opacity = 0;
    document.getElementById("myForm").style.transform = "translate(-50%, 100%)";
    setTimeout(function () {
        document.getElementById("myForm").style.display = "none";
        document.querySelector(".overlay").style.display = "none";
        document.body.style.overflow = 'auto'; // разблокировка скролла
    }, 500);
});
//Увійти

//Забули пароль
document.getElementById("showForgot-password").addEventListener("click", function () {
    document.getElementById("myForm").style.opacity = 0;
    document.getElementById("myForm").style.transform = "translate(-50%, 100%)";
    setTimeout(function () {
        document.getElementById("myForm").style.display = "none";
    }, 500);


    document.getElementById("myForm-forgot-password").style.display = "block";
    document.querySelector(".overlay").style.display = "block";
    setTimeout(function () {
        document.getElementById("myForm-forgot-password").style.opacity = 1;
        document.getElementById("myForm-forgot-password").style.transform = "translate(-50%, 44%)";
    }, 100);
    document.body.style.overflow = 'hidden'; // блокировка скролла
});

document.getElementById("closeForm-forgot-password").addEventListener("click", function () {
    document.getElementById("myForm-forgot-password").style.opacity = 0;
    document.getElementById("myForm-forgot-password").style.transform = "translate(-50%, 100%)";
    setTimeout(function () {
        document.getElementById("myForm-forgot-password").style.display = "none";
        document.querySelector(".overlay").style.display = "none";
        document.body.style.overflow = 'auto'; // разблокировка скролла
    }, 500);
});

document.getElementById("btn-back").addEventListener("click", function () {
    document.getElementById("myForm-forgot-password").style.opacity = 0;
    document.getElementById("myForm-forgot-password").style.transform = "translate(-50%, 100%)";

    setTimeout(function () {
        document.getElementById("myForm-forgot-password").style.display = "none";
    }, 500);

    document.getElementById("myForm").style.display = "block";
    setTimeout(function () {
        document.getElementById("myForm").style.opacity = 1;
        document.getElementById("myForm").style.transform = "translate(-50%, 44%)";
    }, 100);
});
//Забули пароль

//Реєстрація
document.getElementById("link-registration").addEventListener("click", function () {
    document.getElementById("myForm").style.opacity = 0;
    document.getElementById("myForm").style.transform = "translate(-50%, 100%)";
    setTimeout(function () {
        document.getElementById("myForm").style.display = "none";
    }, 500);

    document.getElementById("myForm-registration").style.display = "block";
    document.querySelector(".overlay").style.display = "block";
    setTimeout(function () {
        document.getElementById("myForm-registration").style.opacity = 1;
        document.getElementById("myForm-registration").style.transform = "translate(-50%, 44%)";
    }, 100);
});

document.getElementById("closeForm-registration").addEventListener("click", function () {
    document.getElementById("myForm-registration").style.opacity = 0;
    document.getElementById("myForm-registration").style.transform = "translate(-50%, 100%)";
    setTimeout(function () {
        document.getElementById("myForm-registration").style.display = "none";
        document.querySelector(".overlay").style.display = "none";
        document.body.style.overflow = 'auto'; // разблокировка скролла
    }, 500);
});

document.getElementById("link-login").addEventListener("click", function () {
    document.getElementById("myForm-registration").style.opacity = 0;
    document.getElementById("myForm-registration").style.transform = "translate(-50%, 100%)";
    setTimeout(function () {
        document.getElementById("myForm-registration").style.display = "none";
    }, 500);

    document.getElementById("myForm").style.display = "block";
    document.querySelector(".overlay").style.display = "block";
    setTimeout(function () {
        document.getElementById("myForm").style.opacity = 1;
        document.getElementById("myForm").style.transform = "translate(-50%, 44%)";
    }, 100);
});
//Реєстрація
