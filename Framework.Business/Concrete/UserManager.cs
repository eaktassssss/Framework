using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Framework.DTO.Account;

namespace Framework.Business.Concrete
{
    public class UserManager: IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Delete(User entity)
        {
            _userDal.Delete(entity);
        }

        public List<User> GetList()
        {
            return _userDal.GetList();
        }

        public List<User> GetList(Expression<Func<User, bool>> filter)
        {
            return _userDal.GetList(filter);
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        public User Add(User entity)
        {
            return _userDal.Add(entity);
        }

        public User Update(User entity)
        {
            return _userDal.Update(entity);
        }

        public void Delete(int id)
        {
            _userDal.Delete(id);
        }

        public List<UserRoleDto> GetUserRoles(User user)
        {
           return _userDal.GetUserRoles(user);
        }
    }
}
