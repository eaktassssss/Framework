using AutoMapper;
using Framework.DataAccess.Context;
using Framework.DTO.Categories;
using Framework.DTO.Products;

namespace Framework.Business.Mapper.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
            CreateMap<CategoryDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
