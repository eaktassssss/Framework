using Framework.DataAccess.Context;
using Framework.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Framework.Business.Abstract
{
    public interface ICategoryService
    {
        void Delete(CategoryDto entity);
        List<CategoryDto> GetList();
        List<CategoryDto> GetList(Expression<Func<Categories, bool>> filter);
        CategoryDto Get(Expression<Func<Categories, bool>> filter);
        CategoryDto Add(CategoryDto entity);
        CategoryDto Update(CategoryDto entity);
        void Delete(int id);
        List<CategoryDto> GetCategoryDropdownList();
    }
}
