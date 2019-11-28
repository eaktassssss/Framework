using System.Collections.Generic;
using Framework.Core.DataAccess.EntityFramework;
using Framework.DataAccess.Context;
using Framework.DTO.Account;
using Framework.DTO.Users;

namespace Framework.DataAccess.Abstract
{
    public interface IUserDal: IRepository<Users>
    {
        List<UserRolesDto> GetUserRoles(UserDto user);
    }
}
