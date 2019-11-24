using Framework.Business.Abstract;
using Framework.Business.ValidationRules.FluentValidation;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Framework.Core.Aspects.Postsharp;
using Framework.Core.Aspects.Postsharp.ValidationAspects;
using Framework.Core.Aspects.Postsharp.TransactionAspects;
using Framework.Core.Aspects.Postsharp.CacheAspects;
using Framework.Core.Aspects.Postsharp.ExceptionAspects;
using Framework.Core.CrossCuttingConcerns.Caching.Microsoft;
using Framework.Core.Aspects.Postsharp.LogAspects;
using Framework.Core.Aspects.Postsharp.SecuredAspects;
using Framework.Core.CrossCuttingConcerns.Logging.log4net;

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
        //[ValidationAspect(typeof(ProductValidator))]
        /*
        *CacheRemoveAspect
        */
        //[CacheRemoveAspect(null,typeof(MemoryCacheManager))]
        //[LogAspect(typeof(DatabaseLogger))]
        //[LogAspect(typeof(FileLogger))]
        //[ExceptionAspect(typeof(DatabaseLogger))]
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
        [LogAspect(typeof(DatabaseLogger))]
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation(Roles="Admin")]
        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public List<Product> GetList(Expression<Func<Product, bool>> filter)
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
