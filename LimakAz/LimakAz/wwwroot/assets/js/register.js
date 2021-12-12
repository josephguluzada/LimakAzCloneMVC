// Register page Show/Hide Password

const showBtn = Array.from(document.querySelectorAll(".showPass"));

showBtn.forEach(element => {
    element.addEventListener("click", function () {
        if (element.previousElementSibling.type == "password") {
            element.previousElementSibling.type = "text";
        } else {
            element.previousElementSibling.type = "password";
        }
    })
});

