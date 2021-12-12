// Visibility of User Panel Password

const eyeBtn = document.getElementById("eyeBtn");
const eyeIcon = document.querySelector("#eyeBtn i");
const passwordInput = document.getElementById("currentPass");



eyeBtn.addEventListener("click", function () {
    if (eyeIcon.classList.contains("fa-eye-slash")) {
        eyeIcon.classList.remove("fa-eye-slash");
        eyeIcon.classList.add("fa-eye");
        passwordInput.type = "text"
    } else {
        eyeIcon.classList.remove("fa-eye");
        eyeIcon.classList.add("fa-eye-slash");
        passwordInput.type = "password"
    }
})