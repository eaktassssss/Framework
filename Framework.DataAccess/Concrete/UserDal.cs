using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Account;
using System.Collections.Generic;
using System.Linq;

namespace Framework.DataAccess.Concrete
{
    public class UserDal: RepositoryBase<FrameworkContext, User>, IUserDal
    {
        public List<UserRoleDto> GetUserRoles(User user)
        {
            using(var context = new FrameworkContext())
            {
                var result = from userRole in context.UserRoles
                             join
                                 role in context.Roles on
                                 userRole.RoleId equals role.Id
                             where userRole.UserId == user.Id
                             select new UserRoleDto
                             {
                                 RoleName = role.Name
                             };
                return result.ToList();
            }
        }
    }
}
