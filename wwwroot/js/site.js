﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var acc = document.getElementsByClassName("accordion");
var i;

for (i = 0; i < acc.length; i++) {
    acc[i].addEventListener("click", function () {
        this.classList.toggle("active");
        var panel = this.nextElementSibling;
        if (panel.style.display === "block") {
            panel.style.display = "none";
        } else {
            panel.style.display = "block";
        }
    });
}

function updateCartModal() {
    $.ajax({
        url: actionUrls.cartIndexUrl, // Use the global URL variable here
        type: 'GET',
        success: function (data) {
            $('#cartModal .modal-body').html(data);
        },
        error: function (error) {
            console.error("Error updating cart modal:", error);
        }
    });
}


