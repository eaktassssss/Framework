using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.DTO.Products;
using AutoMapper;
using Framework.Core.Aspects.Postsharp.CacheAspects;
using Framework.Core.Aspects.Postsharp.LogAspects;
using Framework.Core.CrossCuttingConcerns.Caching.Microsoft;
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


        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public ProductDto Add(ProductDto entity)
        {
            var model = Mapper.Map<Products>(entity);
            return Mapper.Map<ProductDto>(_productDal.Add(model));
        }



        [CacheAspect(typeof(MemoryCacheManager))]
        public List<ProductListDto> GetProductList(Expression<Func<ProductListDto, bool>> filter = null)
        {
            try
            {
                var result = _productDal.GetList(filter);
                return result;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }



        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(ProductDto entity)
        {
            _productDal.Delete(Mapper.Map<Products>(entity));
        }



        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public void Delete(int id)
        {
            _productDal.Delete(id);
        }


        public ProductDto Get(Expression<Func<Products, bool>> filter)
        {
            var model = _productDal.Get(filter);
            return Mapper.Map<ProductDto>(model);
        }
        public List<ProductDto> GetList()
        {
            return Mapper.Map<List<ProductDto>>(_productDal.GetList());
        }
        public List<ProductDto> GetList(Expression<Func<Products, bool>> filter)
        {
            return Mapper.Map<List<ProductDto>>(_productDal.GetList(filter));
        }


        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public ProductDto Update(ProductDto entity)
        {
            var model = Mapper.Map<Products>(entity);
            return Mapper.Map<ProductDto>(_productDal.Update(model));
        }
    }
}
