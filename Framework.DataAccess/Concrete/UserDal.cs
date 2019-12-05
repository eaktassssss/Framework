using System;
using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Account;
using Framework.DTO.Users;
using System.Collections.Generic;
using System.Linq;

namespace Framework.DataAccess.Concrete
{
    public class UserDal: RepositoryBase<FrameworkContext, Users>, IUserDal
    {
        /*
         * Bu method kullanıcı login olurken o kullanıcıya ait RoleName'lerini döner 
         * Daha sonra bu roleName'ler  ticket oluşturma esnasında encrypt edip cookie eklenir ve pricipal'a atanır.
         */
        public List<RoleNamesDto> GetUserRoleNames(UserDto user)
        {
            using(var context = new FrameworkContext())
            {
                var result = from userRole in context.UserRoles
                             join
                                 role in context.Roles on
                                 userRole.RoleId equals role.Id
                             where userRole.UserId == user.Id
                             select new RoleNamesDto
                             {
                                 RoleName = role.Name
                             };
                return result.ToList();
            }
        }
    }
}
