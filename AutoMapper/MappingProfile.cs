using AutoMapper;
using Product_Catalog.Properties.Models;
using Product_Catalog.Properties.Models.DTOs;

namespace Product_Catalog.AutoMapper;

using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDTO>().ReverseMap();
    }
}