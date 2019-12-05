using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.DataAccess.Context;
using Framework.DTO.Account;
using Framework.DTO.Users;

namespace Framework.Business.Abstract
{
    public interface IUserRolesService
    {
        void Delete(UserRolesDto entity);
        List<UserRolesDto> GetList();
        List<UserRolesDto> GetList(Expression<Func<UserRoles, bool>> filter);
        UserRolesDto Get(Expression<Func<UserRoles, bool>> filter);
        UserRolesDto Add(UserRolesDto entity);
        UserRolesDto Update(UserRolesDto entity);
        void Delete(int id);
    }
}
