// Index page Show/Hide Password

const showBtnTwo = Array.from(document.querySelectorAll(".showPass"));

showBtnTwo.forEach(element => {
    element.addEventListener("click", function () {
        if (element.previousElementSibling.type == "password") {
            element.previousElementSibling.type = "text";
        } else {
            element.previousElementSibling.type = "password";
        }
    })
});


