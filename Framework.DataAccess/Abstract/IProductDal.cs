using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataAccess.Abstract
{
    public interface IProductDal : IRepository<Products>
    {
    }
}
