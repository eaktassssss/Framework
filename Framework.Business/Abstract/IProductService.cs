using Framework.DataAccess.Context;
using Framework.DTO.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Business.Abstract
{
    public interface IProductService
    {
        List<ProductListDto> GetProductList(Expression<Func<ProductListDto, bool>> filter = null);
        void Delete(ProductDto entity);
        List<ProductDto> GetList();
        List<ProductDto> GetList(Expression<Func<Products, bool>> filter);
        ProductDto Get(Expression<Func<Products, bool>> filter);
        ProductDto Add(ProductDto entity);
        ProductDto Update(ProductDto entity);
        void Delete(int id);
    }
}
