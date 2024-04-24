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
               .HasOne(p => p.Category)
               .WithMany(c => c.Products)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of category if products exist

            // Configure Product-SubCategory Relationships (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.SubCategory)
                .WithMany(sc => sc.Products)
                .HasForeignKey(p => p.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent deletion of subcategory if products exist

            // Configure Category-SubCategory Relationships (One-to-Many)
            modelBuilder.Entity<SubCategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(sc => sc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);  // Cascade delete subcategories when a category is deleted

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


            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Fruits", ImageUrl = "/images/cat-1.png" },
                new Category { CategoryId = 2, Name = "Vegetables", ImageUrl = "/images/cat-2.png" },
                new Category { CategoryId = 3, Name = "Dairy", ImageUrl = "/images/cat-3.png" },
                new Category { CategoryId = 4, Name = "Beverages", ImageUrl = "/images/cat-4.png" }
            );


            // Seed data for Sub-Categories
            modelBuilder.Entity<SubCategory>().HasData(
                new SubCategory { SubCategoryId = 1, Name = "Citrus", CategoryId = 1 },
                new SubCategory { SubCategoryId = 2, Name = "Root", CategoryId = 2 },
                new SubCategory { SubCategoryId = 3, Name = "Leafy Greens", CategoryId = 2 },
                new SubCategory { SubCategoryId = 4, Name = "Milk", CategoryId = 3 },
                new SubCategory { SubCategoryId = 5, Name = "Cheese", CategoryId = 3 },
                new SubCategory { SubCategoryId = 6, Name = "Sodas", CategoryId = 4 },
                new SubCategory { SubCategoryId = 7, Name = "Juices", CategoryId = 4 }
            );

            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Orange", Price = 0.50, SubCategoryId = 1, CategoryId = 1, Description = "Fresh Oranges", StockQuantity = 150 },
                new Product { ProductId = 2, Name = "Carrot", Price = 0.20, SubCategoryId = 2, CategoryId = 2, Description = "Organic Carrots", StockQuantity = 200 },
                new Product { ProductId = 3, Name = "Spinach", Price = 1.00, SubCategoryId = 3, CategoryId = 2, Description = "Fresh Spinach", StockQuantity = 100 },
                new Product { ProductId = 4, Name = "Whole Milk", Price = 0.89, SubCategoryId = 4, CategoryId = 3, Description = "Creamy Whole Milk", StockQuantity = 300 },
                new Product { ProductId = 5, Name = "Cheddar Cheese", Price = 2.50, SubCategoryId = 5, CategoryId = 3, Description = "Aged Cheddar Cheese", StockQuantity = 95 },
                new Product { ProductId = 6, Name = "Coca Cola", Price = 1.25, SubCategoryId = 6, CategoryId = 4, Description = "Classic Coca Cola", StockQuantity = 500 },
                new Product { ProductId = 7, Name = "Apple Juice", Price = 1.50, SubCategoryId = 7, CategoryId = 4, Description = "Pure Apple Juice", StockQuantity = 150 }
            );

        }

    }
}
