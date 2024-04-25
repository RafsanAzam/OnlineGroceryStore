using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }

}
