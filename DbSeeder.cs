using Product_Catalog.Data;
using Product_Catalog.Properties.Models;

namespace Product_Catalog;

public static class DbSeeder
{
    public static async Task SeedCategoriesAsync(ProductCatalogContext context)
    {
        if (!context.Categories.Any())  // Перевірка, чи є категорії в базі
        {
            var categories = new List<Category>
            {
                new Category { Name = "Electronics" },
                new Category { Name = "Clothing" },
                new Category { Name = "Toys" }
            };
            await context.Categories.AddRangeAsync(categories);  // Додаємо категорії
            await context.SaveChangesAsync();  // Зберігаємо зміни
        }
    }

    public static async Task SeedProductsAsync(ProductCatalogContext context)
    {
        if (!context.Products.Any())  // Перевірка, чи є продукти в базі
        {
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 999.99m, CategoryId = 1 },
                new Product { Name = "Shirt", Price = 19.99m, CategoryId = 2 },
                new Product { Name = "Toy Car", Price = 15.50m, CategoryId = 3 }
            };
            await context.Products.AddRangeAsync(products);  // Додаємо продукти
            await context.SaveChangesAsync();  // Зберігаємо зміни
        }
    }
}
