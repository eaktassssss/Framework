using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Framework.Business.Abstract;
using Framework.DataAccess.Abstract;
using Framework.DataAccess.Context;
using Framework.DTO.Account;

namespace Framework.Business.Concrete
{
    public class UserRolesManager : IUserRolesService
    {
        private readonly IUserRolesDal _userRolesDal;

        public UserRolesManager(IUserRolesDal userRolesDal)
        {
            _userRolesDal = userRolesDal;
        }
        public void Delete(UserRolesDto entity)
        {
            _userRolesDal.Delete(Mapper.Map<UserRoles>(entity));
        }

        public List<UserRolesDto> GetList()
        {
            return Mapper.Map<List<UserRolesDto>>(_userRolesDal.GetList());
        }

        public List<UserRolesDto> GetList(Expression<Func<UserRoles, bool>> filter)
        {
            return Mapper.Map<List<UserRolesDto>>(_userRolesDal.GetList(filter));
        }

        public UserRolesDto Get(Expression<Func<UserRoles, bool>> filter)
        {
            return Mapper.Map<UserRolesDto>(_userRolesDal.Get(filter));
        }

        public UserRolesDto Add(UserRolesDto entity)
        {
            var model = Mapper.Map<UserRoles>(entity);
            return Mapper.Map<UserRolesDto>(_userRolesDal.Add(model));
        }

        public UserRolesDto Update(UserRolesDto entity)
        {
            var model = Mapper.Map<UserRoles>(entity);
            return Mapper.Map<UserRolesDto>(_userRolesDal.Update(model));
        }

        public void Delete(int id)
        {
            _userRolesDal.Delete(id);
        }
    }
}
