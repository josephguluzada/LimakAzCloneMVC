const listElements = Array.from(document.querySelectorAll(".nav-tabs .nav-item .nav-link"))

window.onload = function () {
    listElements[0].classList.add("active")
}

function RemoveActives() {
    listElements.forEach(x => {
        x.classList.remove("active")
    })
}


listElements.forEach(x => {
    x.addEventListener("click", function (e) {
        e.preventDefault()

        RemoveActives()
        x.classList.add("active")
    })
})