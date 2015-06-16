using System;
using System.Web.Mvc;
using Gradebook.Business.Enums;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.Business.Services;
using Gradebook.Web.Common.CustomAttributes;
using Gradebook.Web.Models.Admin;

namespace Gradebook.Web.Controllers
{
    [LevelAuthorize(UserType.Administrator)]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly ISubjectService _subjectService;
        private readonly IGradeService _gradeService;

        public AdminController(IUserService userService, ISubjectService subjectService, IGradeService gradeService)
        {
            _userService = userService;
            _subjectService = subjectService;
            _gradeService = gradeService;
        }

        #region Teachers

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

        #endregion

        #region Subjects

        public ActionResult Subjects()
        {
            ViewBag.Subjects = _subjectService.GetSubjects();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subjects(AddSubjectModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _subjectService.AddSubject(new SubjectDto {SubjectName = model.Subject});
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }

            }
            ViewBag.Subjects = _subjectService.GetSubjects();
            return View(model);
        }

        #endregion

        public ActionResult AddGrade()
        {
            ViewBag.Grades = _gradeService.GetGradesWithGradeMasters();
            return View();
        }
    }
}
