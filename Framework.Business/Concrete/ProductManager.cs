using Framework.Business.Abstract;
using Framework.Business.ValidationRules.FluentValidation;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Aspects.Postsharp;
using Framework.Core.Aspects.Postsharp.ValidationAspects;
using Framework.Core.Aspects.Postsharp.TransactionAspects;
using Framework.Core.Aspects.Postsharp.CacheAspects;
using Framework.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Framework.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        /*
         *FluentValidationAspect
         */
        [ValidationAspect(typeof(ProductValidator))]
        /*
        *CacheRemoveAspect
        */
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product entity)
        {
            return _productDal.Add(entity);
        }

        public void Delete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public void Delete(int id)
        {
            _productDal.Delete(id);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter);
        }

        /*
         * CacheAspect
         */
        [CacheAspect(typeof(MemoryCacheManager))]
        public IQueryable<Product> GetList()
        {
            return _productDal.GetList();
        }

        public IQueryable<Product> GetList(Expression<Func<Product, bool>> filter)
        {
            return _productDal.GetList(filter);
        }

        /*
         * TransactionAspect
         */
        [TransactionAspect]
        public void TransactionTestMethod(Product product1, Product product2)
        {
            _productDal.Add(product1);
            /*
             * Diğer iş kodlarımız
             */
            _productDal.Update(product2);
        }

        /*
         *FluentValidationAspect
         */
        [ValidationAspect(typeof(ProductValidator))]
        public Product Update(Product entity)
        {
            return _productDal.Update(entity);
        }
    }
}
