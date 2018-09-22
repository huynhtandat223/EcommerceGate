using AutoMapper;
using EcommerceGate.Core.Dto.Products;
using EcommerceGate.Module.Products.Models;

namespace EcommerceGate.Module.Products
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
