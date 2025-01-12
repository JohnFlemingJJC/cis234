using Microsoft.EntityFrameworkCore;
using EFCoreMvcApp.Models;

namespace EFCoreMvcApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor with DbContextOptions
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        // DbSet for Categories
        public DbSet<Category> Categories { get; set; }

        // DbSet for Products
        public DbSet<Product> Products { get; set; }

        // Configure the model and seed data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Books" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Laptop", Price = 1200, CategoryId = 1 },
                new Product { ProductId = 2, Name = "Smartphone", Price = 800, CategoryId = 1 },
                new Product { ProductId = 3, Name = "Fiction Book", Price = 20, CategoryId = 2 }
            );
        }
    }
}