// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const body = document.querySelector("body"),
      sidebar = document.querySelector(".sidebar"),
      toggle = document.querySelector(".menu-icon");


toggle.addEventListener("click", function () {

    expandSidebar();
});

function expandSidebar() {
    sidebar.classList.toggle("close");
    let keepSidebar = document.querySelectorAll("sidebar.close");
    if (keepSidebar.length === 1) {
        localStorage.setItem("keepSidebar", "true");
    } else {
        localStorage.removeItem("keepSidebar");
    }
}

function showStoredSidebar() {
    if (localStorage.getItem("keepSidebar") === "true") {
        sidebar.classList.add("close");

    }
}

showStoredSidebar();

let popup = document.getElementById("logout-popup")

function openPopup() {
    popup.classList.add("open-popup");
}

function closePopup() {
    popup.classList.remove("open-popup");
}
