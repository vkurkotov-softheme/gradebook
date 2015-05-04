using System.Collections.Generic;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;

namespace Gradebook.Business.Services
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetSubjects();
        void AddSubject(SubjectDto subjectDto);
    }
}
