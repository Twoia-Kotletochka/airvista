document.getElementById("showForm").addEventListener("click", function() {
  document.getElementById("myForm").style.display = "block";
  document.querySelector(".overlay").style.display = "block";
  setTimeout(function() {
    document.getElementById("myForm").style.opacity = 1;
    document.getElementById("myForm").style.transform = "translate(-50%, 44%)";
  }, 100);
  document.body.style.overflow = 'hidden'; // блокировка скролла
});

document.getElementById("closeForm").addEventListener("click", function() {
  document.getElementById("myForm").style.opacity = 0;
  document.getElementById("myForm").style.transform = "translate(-50%, 100%)";
  setTimeout(function() {
    document.getElementById("myForm").style.display = "none";
    document.querySelector(".overlay").style.display = "none";
    document.body.style.overflow = 'auto'; // разблокировка скролла
  }, 500);
});