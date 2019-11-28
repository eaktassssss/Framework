using AutoMapper;
using Framework.DataAccess.Context;
using Framework.DTO.Categories;
using Framework.DTO.Products;
using Framework.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.Mapping.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categories,CategoryDto>();
            CreateMap<ProductDto, ProductDto>();
            CreateMap<Users, UserDto>();
        }
    }
}
