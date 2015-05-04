using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Gradebook.Business.Enums;
using Gradebook.Business.Interfaces;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;
using Gradebook.Web.Common.CustomAttributes;
using Gradebook.Web.Models.Admin;

namespace Gradebook.Web.Controllers
{
    [LevelAuthorize(UserType.Administrator)]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult AddTeacher()
        {
            ViewBag.Teachers = _userService.GetTeachers();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTeacher(AddTeacherModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _userService.AddTeacher(new TeacherDto
                    {
                        LastName = model.LastName,
                        MiddleName = model.MiddleName,
                        FirstName = model.FirstName,
                        JobTitle = model.JobTitle,
                        IsAdministrator = model.IsAdministrator
                    });
                    model = new AddTeacherModel();
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            ViewBag.Teachers = _userService.GetTeachers();
            return View(model);
        }
    }
}
