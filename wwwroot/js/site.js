// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
function updateCartCount() {
    $.ajax({
        url: getCartCountUrl, // Using global URL variable
        type: 'GET',
        success: function (count) {
            $('.cart-count').text(count);
        },
        error: function (error) {
            console.error("Error updating cart count:", error);
        }
    });
    
}

$('.add-to-cart-btn').click(function () {
    var productId = $(this).data('product-id');
    var quantity = 1;
    $.ajax({
        url: '/Cart/AddToCart',
        type: 'POST',
        data: { productId: productId, quantity: quantity },
        success: function (response) {
            $('.badge.bg-primary').text(response.CartCount); // assuming the server responds with the new count
        },
        error: function (error) {
            console.error("Error adding to cart:", error);
        }
    });
});

$(document).ready(function () {
    // Decrease item quantity
    $('.quantity-decrease').click(function () {
        var cartItemId = $(this).data('cart-item-id');
        var currentQuantity = parseInt($(this).siblings('.quantity-display').text());
        if (currentQuantity > 1) {
            updateCartItemQuantity(cartItemId, currentQuantity - 1);
        }
    });

    // Increase item quantity
    $('.quantity-increase').click(function () {
        var cartItemId = $(this).data('cart-item-id');
        var currentQuantity = parseInt($(this).siblings('.quantity-display').text());
        updateCartItemQuantity(cartItemId, currentQuantity + 1);
    });

    // Function to update item quantity
    function updateCartItemQuantity(cartItemId, newQuantity) {
        $.ajax({
            url: '/Cart/UpdateQuantity',
            type: 'POST',
            data: {
                cartItemId: cartItemId,
                quantity: newQuantity
            },
            success: function (response) {
                // Update the quantity display
                $('[data-cart-item-id="' + cartItemId + '"]').siblings('.quantity-display').text(newQuantity);
                // Optionally, update the cart count and total price if needed
                updateCartCount();
            },
            error: function (error) {
                console.error("Error updating cart item quantity:", error);
            }
        });
    }

    // Other existing JavaScript code...
});

// Increment item quantity event handler
$('.quantity-increase').click(function () {
    console.log("Increment button clicked"); // Add this log message
    var cartItemId = $(this).data('cart-item-id');
    var currentQuantity = parseInt($(this).prev('.quantity-display').text());
    updateCartItemQuantity(cartItemId, currentQuantity + 1);
});

// Decrement item quantity event handler
$('.quantity-decrease').click(function () {
    console.log("Decrement button clicked"); // Add this log message
    var cartItemId = $(this).data('cart-item-id');
    var currentQuantity = parseInt($(this).next('.quantity-display').text());
    if (currentQuantity > 1) {
        updateCartItemQuantity(cartItemId, currentQuantity - 1);
    }
});











