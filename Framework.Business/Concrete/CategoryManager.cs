using AutoMapper;
using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public CategoryDto Add(CategoryDto entity)
        {
            var model = Mapper.Map<Categories>(entity);
            return Mapper.Map<CategoryDto>(_categoryDal.Add(model));
        }

        public void Delete(CategoryDto entity)
        {
            _categoryDal.Delete(Mapper.Map<Categories>(entity));

        }

        public void Delete(int id)
        {
            _categoryDal.Delete(id);

        }

        public List<CategoryDto> GetCategoryDropdownList()
        {
            var result = _categoryDal.GetCategoryDropdownList();
            return result;
        }

        public CategoryDto Get(Expression<Func<Categories, bool>> filter)
        {
            return Mapper.Map<CategoryDto>(_categoryDal.Get(filter));
        }

        public List<CategoryDto> GetList()
        {
            return Mapper.Map<List<CategoryDto>>(_categoryDal.GetList());
        }

        public List<CategoryDto> GetList(Expression<Func<Categories, bool>> filter)
        {
            return Mapper.Map<List<CategoryDto>>(_categoryDal.GetList(filter));
        }

        public CategoryDto Update(CategoryDto entity)
        {
            var model = Mapper.Map<Categories>(entity);
            return Mapper.Map<CategoryDto>(_categoryDal.Update(model));
        }
    }
}
