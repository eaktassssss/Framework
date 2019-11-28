using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
