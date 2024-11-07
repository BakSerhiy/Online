namespace Product_Catalog.Properties.Models.DTOs;

public class CategoryRequestDto
{
    public string? SearchTerm { get; set; }
    public string SortBy { get; set; } = "Name";
    public bool SortDescending { get; set; } = false;
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}