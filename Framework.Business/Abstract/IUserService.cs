using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.DataAccess.Context;
using Framework.DTO.Account;
using Framework.DTO.Users;

namespace Framework.Business.Abstract
{
    public interface IUserService
    {
        void Delete(UserDto entity);
        List<UserDto> GetList();
        List<UserDto> GetList(Expression<Func<Users, bool>> filter);
        UserDto Get(Expression<Func<Users, bool>> filter);
        UserDto Add(UserDto entity);
        UserDto Update(UserDto entity);
        void Delete(int id);
        /*
         * Bu method kullanıcı login olurken o kullanıcıya ait RoleName'lerini döner 
         * Daha sonra bu roleName'ler  ticket oluşturma esnasında encrypt edip cookie eklenir ve pricipal'a atanır.
         */
        List<RoleNamesDto> GetUserRoleNames(UserDto user);
    }
}
