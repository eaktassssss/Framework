using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DataAccess.Concrete
{
    public class CategoryDal:RepositoryBase<FrameworkContext,Categories>,ICategoryDal
    {
    }
}
