using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gradebook.Business.Enums;
using Gradebook.Business.Interfaces;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;
using Gradebook.Web.Common.FormsAuthentification;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Gradebook.Web.Models;

namespace Gradebook.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFormsAuthenticationService _formsService;
        
        public AccountController(IUserService userService, IFormsAuthenticationService formsService)
        {
            _userService = userService;
            _formsService = formsService;
        }

        //
        // GET: /Account/Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                if (_userService.ValidateUser(model.Email, model.Password))
                {
                    var user = _userService.GetUser(model.Email);
                    var userType = _userService.GetUserType(model.Email);
                    SignIn(user, model.RememberMe, userType);
                    _userService.UpdateLastLoginTime(user);
                }
                return View(model);
            }

            return null;
        }

        //
        // GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var modelDto = new TeacherDto
                {
                    FirstName = model.FirstName,
                    Email = model.Email,
                    BirthDate = model.BirthDate,
                    IsAdministrator = model.IsAdministrator,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    Password = model.Password,
                    UserType = model.UserType
                };

                _userService.CreateTeacher(modelDto);
            }

            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        private void SignIn(User user, bool rememberMe, UserType userType)
        {
            _formsService.SignIn(user, rememberMe, userType);
        }
    }
}