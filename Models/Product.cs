using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }
        public string Description { get; set; }
        //public string ImagePath { get; set; } // Added ImagePath for product images

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        public int StockQuantity { get; set; }

        // Collection of OrderDetails
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
