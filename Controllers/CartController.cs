using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.Services;

public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult Index()
    {
        var cart = _cartService.GetCart(1); // Assuming the cartId is 1
        ViewBag.CartCount = _cartService.GetCartCount(1); // Update the cart count
        return View(cart);
    }


    [HttpPost]
    public IActionResult AddToCart(int productId, int quantity)
    {
        var cartId = 1; // For now, we use a static cartId. This should be dynamic based on session or user.
        _cartService.AddToCart(cartId, productId, quantity);
        var cartCount = _cartService.GetCartCount(cartId);
        ViewBag.CartCount = _cartService.GetCartCount(cartId);
        return Json(new { CartCount = ViewBag.CartCount });
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int cartItemId)
    {
        var cartId = 1;
        _cartService.RemoveFromCart(cartId, cartItemId);

        // Return JSON with new cart count for AJAX call
        var cartCount = _cartService.GetCartCount(cartId);
        return Json(new { CartCount = cartCount });
    }

    [HttpPost]
    public IActionResult UpdateQuantity(int cartItemId, int quantity)
    {
        var cartId = 1;
        _cartService.UpdateQuantity(cartId, cartItemId, quantity);

        // Return JSON with new cart count for AJAX call
        var cartCount = _cartService.GetCartCount(cartId);
        return Json(new { CartCount = cartCount });
    }

    public IActionResult ClearCart()
    {
        var cartId = 1;
        _cartService.ClearCart(cartId);

        // Return JSON with new cart count for AJAX call
        var cartCount = _cartService.GetCartCount(cartId);
        return Json(new { CartCount = cartCount });
    }

    public IActionResult GetCartCount()
    {
        var cartId = 1; // Replace this with actual cart ID retrieval logic
        var cartCount = _cartService.GetCartCount(cartId);
        return Json(cartCount);
    }

}
