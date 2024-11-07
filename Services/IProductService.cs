using Product_Catalog.Properties.Models.DTOs;

namespace Product_Catalog.Services;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
    Task<ProductDTO> GetProductByIdAsync(int id);
    Task AddProductAsync(ProductDTO productDto);
    Task UpdateProductAsync(int id, ProductDTO productDto);
    Task DeleteProductAsync(int id);
}