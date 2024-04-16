using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; } // Nullable for top-level categories

        // Navigation properties
        public Category ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; }
        public List<Product> Products { get; set; }
    }
}
