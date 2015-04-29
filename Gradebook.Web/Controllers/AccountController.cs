using System.Web.Mvc;
using Gradebook.Business.Enums;
using Gradebook.Business.Interfaces;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;
using Gradebook.Web.Common.FormsAuthentification;
using Gradebook.Web.Models;

namespace Gradebook.Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        #region Private Fields

        private readonly IUserService _userService;
        private readonly IFormsAuthenticationService _formsService;

        #endregion

        #region Constructor

        public AccountController(IUserService userService, IFormsAuthenticationService formsService)
        {
            _userService = userService;
            _formsService = formsService;
        }

        #endregion

        #region Action Methods

        #region Log In

        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
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

        #endregion

        #region Log Out

        public ActionResult LogOut()
        {
            _formsService.SignOut();
            return RedirectToAction("LogIn", "Account");
        }

        #endregion


        #region Register

        public ActionResult Register()
        {
            return View();
        }

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

        #endregion

        #region Reset Password

        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        #endregion

        #endregion

        #region Private Methods

        private void SignIn(User user, bool rememberMe, UserType userType)
        {
            _formsService.SignIn(user, rememberMe, userType);
        }

        #endregion
    }
}