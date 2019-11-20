using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.Business.Concrete
{
    public class CategoryManager: ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Delete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public IQueryable<Category> GetList()
        {
            return _categoryDal.GetList();
        }

        public IQueryable<Category> GetList(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.GetList(filter);
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        public Category Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        public Category Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }

        public void Delete(int id)
        {
            _categoryDal.Delete(id);
        }
    }
}
