// Login page Show/Hide Password

const showBtn = document.querySelector(".showPass");


showBtn.addEventListener("click", function () {
    if (showBtn.previousElementSibling.type == "password") {
        showBtn.previousElementSibling.type = "text";
    } else {
        showBtn.previousElementSibling.type = "password";
    }
})