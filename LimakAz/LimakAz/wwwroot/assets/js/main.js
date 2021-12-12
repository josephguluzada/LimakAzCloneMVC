


// Accordion

const accordion = document.getElementsByClassName("content-box");

function removeActivesInAccordion() {
    for (let i = 0; i < accordion.length; i++) {
        accordion[i].classList.remove("active");
    }
}

for (let i = 0; i < accordion.length; i++) {
    accordion[i].addEventListener("click", function () {
        removeActivesInAccordion();
        accordion[i].classList.toggle("active");
    })

}



// User Panel Button

const userBtn = document.querySelector(".user-panel-btn");
const dropDownContent = document.querySelector(".dropdown-menu");

userBtn.addEventListener("click", (e) => {
    if (e.target.id === "userPanelBtn")
        dropDownContent.classList.toggle("active");
})

document.addEventListener("mouseup", (e) => {
    if (e.target.id !== "userPanelBtn" && e.target.id !== "userPanelList")
        dropDownContent.classList.remove("active");
})


// User Panel Content Header

const flagBtn = document.querySelectorAll("#headerList .nav-item .nav-link");
const tabPane = Array.from(document.querySelectorAll(".active-tab"));

function removeActivesInFlag() {
    for (let i = 0; i < flagBtn.length; i++) {
        flagBtn[i].classList.remove("active");
    }
}

function removeActivesInTabPane() {
    for (let i = 0; i < tabPane.length; i++) {
        tabPane[i].classList.remove("active");
    }
}

for (let i = 0; i < flagBtn.length; i++) {
    flagBtn[i].addEventListener("click", function () {
        if (!flagBtn[i].classList.contains("active")) {
            removeActivesInFlag();
            flagBtn[i].classList.add("active")
        }
        removeActivesInTabPane();
        let target = this.getAttribute("data-target");
        tabPane.forEach(el => {
            if (target == el.getAttribute("data-id")) {
                el.classList.add("active");
            }
        })
    })
}


// Package Show Button

const showBtn = Array.from(document.querySelectorAll(".package-table button"));
const collapseDiv = Array.from(document.querySelectorAll(".collapse"));

for (let i = 0; i < showBtn.length; i++) {
    showBtn[i].addEventListener("click", function () {
        let target = this.getAttribute("data-target")
        collapseDiv.forEach(el => {
            if (target == el.getAttribute("data-id")) {
                el.classList.toggle("show")
            }
        })
    })
}


// Copy to Clipboard

const copyText = Array.from(document.querySelectorAll("#copyText"));
const copyBtn = Array.from(document.querySelectorAll(".copy"));


for (let i = 0; i < copyBtn.length; i++) {
    copyBtn[i].addEventListener("click", function () {
        let target = this.getAttribute("data-target")
        console.log(target);
        copyText.forEach(el => {
            if (target == el.getAttribute("data-id")) {
                let text = el.textContent;
                navigator.clipboard.writeText(text);
            }
        })
    })
}






// Courier Page Input Check

const checkLabel = document.querySelectorAll(".custom-control .ccl");
const checkInput = document.querySelectorAll(".custom-control .custom-control-input");

function removeActivesInInput() {
    for (let i = 0; i < checkLabel.length; i++) {
        checkLabel[i].classList.remove("custom-radio-dot");
    }
}



for (let i = 0; i < checkLabel.length; i++) {
    checkLabel[i].addEventListener("click", function () {
        let target = this.getAttribute("for");

        checkInput.forEach(el => {
            if (target == el.getAttribute("id")) {
                if (el.checked = true) {
                    removeActivesInInput();
                    checkLabel[i].classList.toggle("custom-radio-dot");
                }
            }
        })
    })
}


// Second Part
const checkLabelTwo = document.querySelectorAll(".check-custom-block .ccl-2");
const checkInputTwo = document.querySelectorAll(".check-custom-block .custom-control-input-2");

function removeActivesInInputTwo() {
    for (let i = 0; i < checkLabelTwo.length; i++) {
        checkLabelTwo[i].classList.remove("custom-radio-dot-2");
    }
}

for (let i = 0; i < checkLabelTwo.length; i++) {
    checkLabelTwo[i].addEventListener("click", function () {
        let target = this.getAttribute("for");

        checkInputTwo.forEach(el => {
            if (target == el.getAttribute("id")) {

                removeActivesInInputTwo();
                checkLabelTwo[i].classList.toggle("custom-radio-dot-2");

            }
        })
    })
}






