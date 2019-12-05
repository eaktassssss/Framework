using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Products;

namespace Framework.DataAccess.Concrete
{
    public class ProductDal : RepositoryBase<FrameworkContext, Products>, IProductDal
    {
        public List<ProductListDto> GetList(Expression<Func<ProductListDto, bool>> filter = null)
        {
            using (var context = new FrameworkContext())
            {
                var result = from product in context.Products
                             join
                                 category in context.Categories on
                                 product.CategoryID equals category.CategoryID
                             select new ProductListDto
                             {
                                 CategoryName = category.CategoryName,
                                 ProductID = product.ProductID,
                                 ProductName = product.ProductName,
                                 UnitPrice = (decimal)product.UnitPrice,
                                 UnitsInStock = (short)product.UnitsInStock,
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
