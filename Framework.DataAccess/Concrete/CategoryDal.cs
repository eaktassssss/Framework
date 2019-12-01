using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO.Categories;

namespace Framework.DataAccess.Concrete
{
    public class CategoryDal:RepositoryBase<FrameworkContext,Categories>,ICategoryDal
    {
        public List<CategoryDto> GetCategoryDropdownList()
        {
            using (var context =new FrameworkContext())
            {
                return context.Categories.Select(category => new CategoryDto()
                {
                    CategoryID=category.CategoryID,CategoryName=category.CategoryName
                }).ToList();
            }
        }
    }
}
