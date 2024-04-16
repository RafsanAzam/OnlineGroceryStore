using Microsoft.EntityFrameworkCore;

namespace OnlineGroceryStore.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory>SubCategories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Product-Category Relationships (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)  // Each product has one category
                .WithMany(c => c.Products)  // Each category has many products
                .HasForeignKey(p => p.CategoryId);  // Foreign key in Product table

            // Configure Category Self-Referencing for Sub-Categories (One-to-Many)
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)  // Each sub-category has one parent category
                .WithMany(c => c.SubCategories)  // Each parent category has many sub-categories
                .HasForeignKey(c => c.ParentCategoryId)  // Nullable foreign key in Category table
                .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of a category if it has sub-categories

            // Configure Order-OrderDetail Relationships (One-to-Many)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)  // Each order detail is associated with one order
                .WithMany(o => o.OrderDetails)  // Each order has many order details
                .HasForeignKey(od => od.OrderId);  // Foreign key in OrderDetail table

            // Configure Product-OrderDetail Relationships (One-to-Many)
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)  // Each order detail is associated with one product
                .WithMany(p => p.OrderDetails)  // Each product can be in many order details
                .HasForeignKey(od => od.ProductId);  // Foreign key in OrderDetail table

            // Optionally: Configure additional settings for properties, such as string lengths, indexes, etc.
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);


            // Seed Categories with Sub-Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Fruits", ParentCategoryId = null },
                new Category { CategoryId = 2, Name = "Vegetables", ParentCategoryId = null },
                new Category { CategoryId = 3, Name = "Dairy", ParentCategoryId = null },

                // Adding sub-categories
                new Category { CategoryId = 4, Name = "Citrus Fruits", ParentCategoryId = 1 },
                new Category { CategoryId = 5, Name = "Stone Fruits", ParentCategoryId = 1 },
                new Category { CategoryId = 6, Name = "Root Vegetables", ParentCategoryId = 2 },
                new Category { CategoryId = 7, Name = "Leafy Greens", ParentCategoryId = 2 },
                new Category { CategoryId = 8, Name = "Milk", ParentCategoryId = 3 },
                new Category { CategoryId = 9, Name = "Cheese", ParentCategoryId = 3 }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Apple", Price = 0.50, CategoryId = 1, Description = "Fresh Apples", StockQuantity = 100 },
                new Product { ProductId = 2, Name = "Banana", Price = 0.30, CategoryId = 1, Description = "Organic Bananas", StockQuantity = 80 },
                new Product { ProductId = 3, Name = "Carrot", Price = 0.20, CategoryId = 2, Description = "Garden Fresh Carrots", StockQuantity = 150 }
            );

        }

    }
}
