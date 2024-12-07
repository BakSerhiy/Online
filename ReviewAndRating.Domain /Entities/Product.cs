namespace ReviewAndRating.Domain.Entities;

public class Product
{
    public Guid Id { get; set; } // Унікальний ідентифікатор товару
    public string Name { get; set; } // Назва товару
    public string Description { get; set; } // Опис товару
}