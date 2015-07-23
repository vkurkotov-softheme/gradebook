using System.Collections.Generic;
using System.Linq;
using Gradebook.Business.Exceptions;
using Gradebook.Business.Helpers;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.Business.Services;
using Gradebook.DAL.EF;
using Gradebook.Translations;

namespace Gradebook.Business.Implemintation
{
    public class GradeService : IGradeService
    {
        private readonly Entities _entities;

        public GradeService(Entities entities)
        {
            _entities = entities;
        }

        public IEnumerable<Grade> GetGradesWithGradeMasters()
        {
            return _entities.Grades.Include("FormMaster");
        }

        public void AddGrade(GradeDto gradeDto)
        {
            AssertHelper.AssertNotNull(gradeDto.GradeName, "GradeName", "GradeName field is not passed");

            if (_entities.Grades.Any(g => g.GradeName == gradeDto.GradeName 
                                       && g.BeginYear == gradeDto.BeginYear
                                       && g.GraduateYear == gradeDto.GraduateYear))
            {
                throw new GradeAlreadyExistsException(string.Format(i18n.SubjectAlreadyExistsException, gradeDto.GradeName));
            }

            var grade = new Grade
            {
                GradeName = gradeDto.GradeName,
                BeginYear = gradeDto.BeginYear,
                GraduateYear = gradeDto.GraduateYear,
                FormMaster = gradeDto.FormMaster,
                Graduated = false
            };

            _entities.Grades.Add(grade);
            _entities.SaveChanges();
        }
    }
}
