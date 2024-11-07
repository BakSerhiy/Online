using AutoMapper;
using Product_Catalog.Properties.Models;
using Product_Catalog.Properties.Models.DTOs;
using Product_Catalog.Repositories;

namespace Product_Catalog.Services;       

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task AddProductAsync(ProductDTO productDto)
    {
        var product = _mapper.Map<Product>(productDto);
        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateProductAsync(int id, ProductDTO productDto)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(id);
        if (product == null) throw new Exception("Product not found");

        _mapper.Map(productDto, product);
        await _unitOfWork.Products.UpdateAsync(product);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        await _unitOfWork.Products.DeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}