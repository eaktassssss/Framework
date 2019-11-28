using Framework.Business.Abstract;
using Framework.Core.CrossCuttingConcerns.Security;
using Framework.DataAccess.Context;
using Framework.DTO.Users;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Framework.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserDto user)
        {
            string[] arrayRoles;
            var getUser = _userService.Get(model => model.UserName == user.UserName && model.Password == user.Password);
            if (getUser != null)
            {
                var roles = _userService.GetUserRoles(getUser);
                if (roles != null)
                {
                    AuthenticationHelper
                    .CreateAuthenticationCookie(Guid.NewGuid(), getUser.UserName, getUser.Email, DateTime.Now.AddDays(5)
                        , roles.Select(x => x.RoleName).ToArray(), false, getUser.FirstName, getUser.LastName);
                    return RedirectToAction("index", "Product");
                }
            }
            return View(user);
        }
    }
}