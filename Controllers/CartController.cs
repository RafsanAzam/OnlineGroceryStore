using Microsoft.AspNetCore.Mvc;
using OnlineGroceryStore.Services;

public class CartController : Controller
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult UpdateCartCount()
    {
        var cartCount = _cartService.GetTotalProductQuantity(1); // Assuming the cartId is 1
        ViewBag.CartCount = cartCount;
        return PartialView("_CartCountPartial", cartCount); // Assuming you have a partial view for cart count
    }

    public IActionResult AjaxGetTotalProductQuantity()
    {
        var cartId = 1; // Assuming a static cart ID for now
        var totalQuantity = _cartService.GetTotalProductQuantity(cartId);
        return Json(new { TotalQuantity = totalQuantity });
    }


    public IActionResult Index()
    {
        var cart = _cartService.GetCart(1); // Assuming the cartId is 1
        ViewBag.CartCount = _cartService.GetTotalProductQuantity(1); // Update the cart count
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

    [HttpPost]
    public IActionResult ClearCart(int cartId)
    {
        try
        {
            _cartService.ClearCart(cartId);
            return RedirectToAction("Index"); // Redirect to cart page or any other page
        }
        catch (Exception ex)
        {
            // Handle the exception or return an error message
            return BadRequest(ex.Message);
        }
    }

    public IActionResult GetCartCount()
    {
        var cartId = 1; // Replace this with actual cart ID retrieval logic
        var cartCount = _cartService.GetCartCount(cartId);
        return Json(cartCount);
    }

    [HttpGet]
    public IActionResult GetTotalProductQuantity()
    {
        var cartId = 1; // Assuming a static cart ID for now
        var totalQuantity = _cartService.GetTotalProductQuantity(cartId);
        return Json(new { TotalQuantity = totalQuantity });
    }

}
