using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.DTO.Products;

namespace Framework.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Products>
    {
        List<ProductListDto> GetList(Expression<Func<ProductListDto, bool>> filter=null);
    }
}
