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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders).HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Apple", Price = 0.50 },
                new Product { ProductId = 2, Name = "Banana", Price = 0.30 },
                new Product { ProductId = 3, Name = "Carrot", Price = 0.20 }
                // Add as many Products as you need here
            );
        }

    }
}
