using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } // Property for storing the image URL
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public List<Product> Products { get; set; }  // Products directly associated with this category
    }
}
