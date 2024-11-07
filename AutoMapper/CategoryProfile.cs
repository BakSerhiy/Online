using AutoMapper;
using Product_Catalog.Properties.Models;
using Product_Catalog.Properties.Models.DTOs;

namespace Product_Catalog.AutoMapper;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
    }
}
