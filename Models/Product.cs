using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int StockQuantity { get; set; }
        public Category Category { get; set; }
    }
}
