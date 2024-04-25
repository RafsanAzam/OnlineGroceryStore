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
        return View(cart);
    }


    [HttpPost]
    public IActionResult AddToCart(int productId, int quantity)
    {
        var cartId = 1; // For now, we use a static cartId. This should be dynamic based on session or user.
        _cartService.AddToCart(cartId, productId, quantity);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult RemoveFromCart(int cartItemId)
    {
        var cartId = 1;
        _cartService.RemoveFromCart(cartId, cartItemId);
        return RedirectToAction("Index");
    }

    public IActionResult UpdateQuantity(int cartItemId, int quantity)
    {
        var cartId = 1;
        _cartService.UpdateQuantity(cartId, cartItemId, quantity);
        return RedirectToAction("Index");
    }

    public IActionResult ClearCart()
    {
        var cartId = 1;
        _cartService.ClearCart(cartId);
        return RedirectToAction("Index");
    }
}
