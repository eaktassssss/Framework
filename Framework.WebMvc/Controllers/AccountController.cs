using Framework.Business.Abstract;
using Framework.Core.CrossCuttingConcerns.Security;
using Framework.DTO.Account;
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
        public ActionResult Login(LoginDto user)
        {
            string[] arrayRoles;
            var getUser = _userService.Get(model => model.UserName == user.UserName && model.Password == user.Password);
            if (getUser != null)
            {
                var roles = _userService.GetUserRoleNames(getUser);
                if (roles != null)
                {
                    AuthenticationHelper
                    .CreateAuthenticationCookie(Guid.NewGuid(), getUser.UserName, getUser.Email, DateTime.Now.AddDays(5)
                        , roles.Select(x => x.RoleName).ToArray(), false, getUser.FirstName, getUser.LastName);
                    return RedirectToAction("List", "Product");
                }
            }
            return View(user);
        }


        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserDto user)
        {
            try
            {
                var result = _userService.Add(user);
                return RedirectToAction("List", "Account");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        [HttpGet]
        public ActionResult List()
        {
            var list = _userService.GetList();
            if (list != null)
            {
                return View(list);
            }
            return View("ErrorPage");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return RedirectToAction("List", "Account");
            }
            catch(Exception exception)
            {
                return View("ErrorPage");
            }
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            try
            {
                var user = _userService.Get(x => x.Id == id);
                if (user !=null)
                {
                    return View(user);
                }
                return View("ErrorPage");
            }
            catch
            {
                return View("ErrorPage");
            }
        }

        [HttpPost]
        public ActionResult Update(UserDto user)
        {
            try
            {
               var result  = _userService.Update(user);
               if (result!=null)
               {
                   return RedirectToAction("List", "Account");
               }
               return View(user);
            }
            catch
            {
                return View("ErrorPage");
            }
        }
    }
}