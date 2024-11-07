using AutoMapper;
using Product_Catalog.Properties.Models;
using Product_Catalog.Properties.Models.DTOs;
using Product_Catalog.Repositories;

namespace Product_Catalog.Services;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return _mapper.Map<IEnumerable<CategoryDto>>(categories);
    }

    public async Task<CategoryDto> GetCategoryByIdAsync(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task AddCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _unitOfWork.Categories.AddAsync(category);
        await _unitOfWork.CompleteAsync();
    }

    public async Task UpdateCategoryAsync(CategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        await _unitOfWork.Categories.UpdateAsync(category);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteCategoryAsync(int id)
    {
        await _unitOfWork.Categories.DeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}