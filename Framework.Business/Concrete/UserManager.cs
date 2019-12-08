using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.DTO.Account;
using Framework.DTO.Users;
using AutoMapper;
using Framework.Core.Aspects.Postsharp.SecuredAspects;

namespace Framework.Business.Concrete
{
    [SecuredOperation(Roles = "Admin")]
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserRolesService _userRolesService;
        public UserManager(IUserDal userDal, IUserRolesService userRolesService)
        {
            _userDal = userDal;
            _userRolesService = userRolesService;
        }
        public void Delete(UserDto entity)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == entity.Id);
                if (user != null)
                {
                    var userRoles = _userRolesService.GetList(x => x.UserId == user.Id);
                    if (userRoles != null)
                    {
                        foreach (var userRole in userRoles)
                        {
                            _userRolesService.Delete(userRole.Id);
                        }
                        _userDal.Delete(user);
                        return;
                    }
                    _userDal.Delete(user);
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

        }

        public List<UserDto> GetList()
        {
            return Mapper.Map<List<UserDto>>(this._userDal.GetList());
        }

        public List<UserDto> GetList(Expression<Func<Users, bool>> filter)
        {
            return Mapper.Map<List<UserDto>>(this._userDal.GetList(filter));
        }

        public UserDto Get(Expression<Func<Users, bool>> filter)
        {
            return Mapper.Map<UserDto>(this._userDal.Get(filter));
        }

        public UserDto Add(UserDto entity)
        {
            var model = Mapper.Map<Users>(entity);
            return Mapper.Map<UserDto>(this._userDal.Add(model));
        }

        public UserDto Update(UserDto entity)
        {
            var model = Mapper.Map<Users>(entity);
            return Mapper.Map<UserDto>(this._userDal.Update(model));
        }

        public void Delete(int id)
        {
            try
            {
                var user = _userDal.Get(x => x.Id == id);
                if (user != null)
                {
                    var userRoles = _userRolesService.GetList(x => x.UserId == user.Id);
                    if (userRoles.Count>0)
                    {
                        foreach (var userRole in userRoles)
                        {
                            _userRolesService.Delete(userRole.Id);
                        }
                        _userDal.Delete(user);
                        return;
                    }
                    _userDal.Delete(user);
                }
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }

        }
        /*
       * Bu method kullanıcı login olurken o kullanıcıya ait RoleName'lerini döner 
       * Daha sonra bu roleName'ler  ticket oluşturma esnasında encrypt edip cookie eklenir ve pricipal'a atanır.
       */
        public List<RoleNamesDto> GetUserRoleNames(UserDto user)
        {
            return _userDal.GetUserRoleNames(user);
        }
    }
}
