﻿using System.Collections.Generic;
using Framework.DataAccess.Context;
using Framework.DTO.Account;

namespace Framework.Business.Abstract
{
    public interface IUserService: IGenericService<User>
    {
        List<UserRoleDto> GetUserRoles(User user);
    }
}
