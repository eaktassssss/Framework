using System.Collections.Generic;
using Framework.DataAccess.Context;
using Framework.Core.DataAccess.EntityFramework;
using Framework.DTO.Categories;

namespace Framework.DataAccess.Abstract
{
    public interface ICategoryDal:IRepository<Categories>
    {
        List<CategoryDto> GetCategoryDropdownList();
    }
}
