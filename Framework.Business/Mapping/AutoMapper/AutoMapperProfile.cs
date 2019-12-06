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
using Framework.Business.Extensions.Mapper.AutoMapper;

namespace Framework.Business.Mapping.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryDto, Categories>();
            CreateMap<ProductDto, Products>().IgnoreVirtualPropertyDestination<ProductDto, Products>();
            CreateMap<UserDto, Users>().IgnoreVirtualPropertyDestination<UserDto, Users>();
        }
    }
}
