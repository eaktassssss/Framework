using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Context;
using Framework.DTO.Account;
using Framework.DTO.Products;

namespace Framework.DataAccess.Abstract
{
    public interface IUserRolesDal:IRepository<UserRoles>
    {
        List<UserRolesListDto> GetList(Expression<Func<UserRolesListDto, bool>> filter = null);
    }
}
