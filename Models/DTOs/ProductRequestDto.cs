namespace Product_Catalog.Properties.Models.DTOs;

public class ProductRequestDto
{
    public string? SearchTerm { get; set; } // Фільтрація
    public string SortBy { get; set; } = "Name"; // За замовчуванням сортування по Name
    public bool SortDescending { get; set; } = false; // Вказує, чи сортувати у зворотньому порядку
    public int Page { get; set; } = 1; // Пагінація (за замовчуванням сторінка 1)
    public int PageSize { get; set; } = 10; // Кількість елементів на сторінці
}