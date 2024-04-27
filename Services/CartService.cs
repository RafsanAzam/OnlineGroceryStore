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
                           .SingleOrDefault(c => c.CartId == 1);
        }

        public void AddToCart(int cartId, int productId, int quantity)
        {
            // Log the product ID and quantity before making the AJAX request
            //Console.WriteLine("Product ID:", productId);
            //Console.WriteLine("Quantity:", quantity);

            // First, try to get the cart from the database.
            var cart = GetCart(cartId);

            // If there's no cart, create a new one and add it to the context.
            /*if (cart == null)
            {
                cart = new Cart { CartId = cartId, CartItems = new List<CartItem>() };
                _context.Carts.Add(cart);
                // No need to call SaveChanges() here, as it's called once at the end.
            }*/

            // Check if the product exists and has sufficient stock.
            var product = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null || product.StockQuantity < quantity)
            {
                // If no product is found or not enough stock, we can either throw an exception or handle it gracefully.
                throw new Exception("Product not found or not enough stock.");
            }

            // Find the cart item for the given product ID.
            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);

            // If the cart item doesn't exist, create a new one.
            if (cartItem == null)
            {
                    cartItem = new CartItem { ProductId = productId, Quantity = quantity };
                    cart.CartItems.Add(cartItem);
            }

            else
            {
                // If the cart item exists, just update the quantity.
                cartItem.Quantity += quantity;
            }

            // Update the stock quantity for the product.
            product.StockQuantity -= quantity;

            // Apply all changes to the database.
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

            foreach (var cartItem in cart.CartItems)
            {
                var product = _context.Products.Find(cartItem.ProductId);
                if (product != null)
                {
                    // Increment the product stock quantity by the quantity in the cart item
                    product.StockQuantity += cartItem.Quantity;
                }
            }

            // Clear the cart items
            cart.CartItems.Clear();

            _context.SaveChanges();
        }

        public int GetCartCount(int cartId)
        {
            var cart = GetCart(cartId);
            return cart?.CartItems.Sum(item => item.Quantity) ?? 0;
        }

        public int GetTotalProductQuantity(int cartId)
        {
            var cart = GetCart(cartId);
            if (cart != null)
            {
                // Sum up the quantities of all cart items
                return cart.CartItems.Sum(item => item.Quantity);
            }
            return 0; // Return 0 if cart is null or cart has no items
        }

    }
}
