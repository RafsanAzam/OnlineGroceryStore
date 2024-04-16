using System.ComponentModel.DataAnnotations;

namespace OnlineGroceryStore.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}
