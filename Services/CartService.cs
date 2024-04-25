using OnlineGroceryStore.Models.Data;
using OnlineGroceryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace OnlineGroceryStore.Services
{
    public class CartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Cart GetCart(int cartId)
        {
            return _context.Carts
                   .Include(c => c.CartItems)
                   .ThenInclude(ci => ci.Product)
                   .FirstOrDefault(c => c.CartId == cartId);
        }

        public void AddToCart(int cartId, int productId, int quantity)
        {
            var cart = GetCart(cartId);
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product == null || product.StockQuantity < quantity)
                throw new Exception("Product is out of stock");

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem == null)
            {
                cart.CartItems.Add(new CartItem { ProductId = productId, Quantity = quantity});
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            _context.SaveChanges();
        }

        public void RemoveFromCart(int cartId, int cartItemId)
        {
            var cart = GetCart(cartId);
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);

            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }
        }

        public void UpdateQuantity(int cartId, int cartItemId, int quantity)
        {
            var cartItem = _context.CartItems.Find(cartItemId);

            if (cartItem != null && quantity > 0)
            {
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }
        }

        public void ClearCart(int cartId)
        {
            var cart = GetCart(cartId);
            cart.CartItems.Clear();
            _context.SaveChanges();
        }
    }
}
