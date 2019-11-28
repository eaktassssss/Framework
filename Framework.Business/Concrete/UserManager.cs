using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.DTO.Account;
using Framework.DTO.Users;
using AutoMapper;

namespace Framework.Business.Concrete
{
    public class UserManager: IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Delete(UserDto entity)
        {
            _userDal.Delete(Mapper.Map<Users>(entity));
        }

        public List<UserDto> GetList()
        {
            return Mapper.Map<List<UserDto>>(_userDal.GetList());
        }

        public List<UserDto> GetList(Expression<Func<Users, bool>> filter)
        {
            return Mapper.Map<List<UserDto>>(_userDal.GetList(filter));
        }

        public UserDto Get(Expression<Func<Users, bool>> filter)
        {
            return Mapper.Map<UserDto>(_userDal.Get(filter));
        }

        public UserDto Add(UserDto entity)
        {
            var model = Mapper.Map<Users>(entity);
            return Mapper.Map<UserDto>(_userDal.Add(model));
        }

        public UserDto Update(UserDto entity)
        {
            var model = Mapper.Map<Users>(entity);
            return Mapper.Map<UserDto>( _userDal.Update(model));
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
        }

        public List<UserRolesDto> GetUserRoles(UserDto user)
        {
           return _userDal.GetUserRoles(user);
        }
    }
}
