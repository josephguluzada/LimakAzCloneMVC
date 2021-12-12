// Calculator Page dropdown content

const dropdownBtn = document.querySelectorAll(".dropdown-toggle");

dropdownBtn.forEach(element => {
    element.addEventListener("click", function () {
        element.nextElementSibling.classList.toggle("active");
    })
})