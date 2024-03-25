using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Product
    {
        [Key]
        public int Productd { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
