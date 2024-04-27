using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.Models;
using OnlineGroceryStore.Models.Data;
using OnlineGroceryStore.Services;
using System.Linq;

namespace OnlineGroceryStore.Controllers
{
    public class DeliveryDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CartService _cartService;

        public DeliveryDetailsController(ApplicationDbContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        // GET: /DeliveryDetails
        public IActionResult Index()
        {
            var deliveryDetails = new DeliveryDetails();
            return View(deliveryDetails);
        }

        // POST: /DeliveryDetails
        [HttpPost]
        public IActionResult Index(DeliveryDetails deliveryDetails)
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return the view with validation errors
                return View(deliveryDetails);
            }

            // Check availability of items in the shopping cart
            var cart = _cartService.GetCart(1);
            var cartItems = cart.CartItems;

            // Flag to check if all items are available
            bool allItemsAvailable = true;

            // Perform availability check for each item
            foreach (var cartItem in cartItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == cartItem.ProductId);
                if (product == null || product.StockQuantity < cartItem.Quantity)
                {
                    // If any item is unavailable or insufficient, redirect to cart with a message
                    TempData["ErrorMessage"] = "Some items in your cart are not available or insufficient in quantity.";
                    return RedirectToAction("Index", "Cart");
                }
            }

            // Proceed with order processing if all items are available
            // For example, save delivery details to the database and process the order
            // Clear the cart since all items are available
            _cartService.ClearCart(1);
            // Redirect to home page with a success message
            TempData["SuccessMessage"] = "Your order has been placed successfully!";
            return RedirectToAction("Index", "Home");

            // Redirect to a confirmation page or another step in the checkout process
            //return RedirectToAction("Confirmation");
        }

        // GET: /DeliveryDetails/Confirmation
        public IActionResult Confirmation()
        {
            // Display a confirmation message to the user
            return View();
        }
    }
}
