using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.DTO.Products;
using AutoMapper;
using Framework.Core.Aspects.Postsharp.SecuredAspects;

namespace Framework.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public ProductDto Add(ProductDto entity)
        {
            var model = Mapper.Map<Products>(entity);
            return Mapper.Map<ProductDto>(_productDal.Add(model));
        }

        public List<ProductListDto> GetProductList(Expression<Func<ProductListDto, bool>> filter = null)
        {
            try
            {
                var result  = _productDal.GetList(filter);
                return result;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public void Delete(ProductDto entity)
        {
            _productDal.Delete(Mapper.Map<Products>(entity));
        }
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
        public ProductDto Update(ProductDto entity)
        {
            var model = Mapper.Map<Products>(entity);
            return Mapper.Map<ProductDto>(_productDal.Update(model));
        }
    }
}
