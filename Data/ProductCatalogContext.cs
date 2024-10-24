using Product_Catalog.Properties.Models;
using Microsoft.EntityFrameworkCore;


namespace Product_Catalog.Data
{
    public class ProductCatalogContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфігурація для Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Інші конфігурації Fluent API
        }
    }
}