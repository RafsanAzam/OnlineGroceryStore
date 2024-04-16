namespace OnlineGroceryStore.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public int ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public List<Product> Products { get; set; }  // Products directly associated with this subcategory
    }
}
