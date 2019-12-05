using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Account;

namespace Framework.DataAccess.Concrete
{
    public class UserRolesDal:RepositoryBase<FrameworkContext,UserRoles>,IUserRolesDal
    {
        public List<UserRolesListDto> GetList(Expression<Func<UserRolesListDto, bool>> filter = null)
        {
            using (var context =new FrameworkContext())
            {
                var result = from userRoles in context.UserRoles
                    join
                        user in context.Users on userRoles.UserId equals user.Id
                    join role in context.Roles on userRoles.RoleId equals role.Id
                    select new UserRolesListDto
                    {
                        RoleName = role.Name,UserName=user.UserName,Id = userRoles.Id

                    };
                return result.ToList();
            }
        }
    }
}
