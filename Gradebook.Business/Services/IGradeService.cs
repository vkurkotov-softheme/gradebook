using System.Collections.Generic;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;

namespace Gradebook.Business.Services
{
    public interface IGradeService
    {
        IEnumerable<Grade> GetGradesWithGradeMasters();

        void AddGrade(GradeDto gradeDto);
    }
}
