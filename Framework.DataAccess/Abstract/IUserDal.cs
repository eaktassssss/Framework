using System.Collections.Generic;
using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Context;
using Framework.DTO.Account;

namespace Framework.DataAccess.Abstract
{
    public interface IUserDal: IRepository<User>
    {
        List<UserRolesDto> GetUserRoles(User user);
    }
}
