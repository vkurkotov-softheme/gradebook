using System.Collections.Generic;
using System.Linq;
using Gradebook.Business.Exceptions;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.Business.Services;
using Gradebook.DAL.EF;
using Gradebook.Translations;

namespace Gradebook.Business.Implemintation
{
    public class SubjectService : ISubjectService
    {
        private readonly Entities _entities;

        public SubjectService(Entities entities)
        {
            _entities = entities;
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return _entities.Subjects;
        }

        public void AddSubject(SubjectDto subjectDto)
        {
            if (_entities.Subjects.Any(s => s.SubjectName == subjectDto.SubjectName))
            {
                throw new SubjectAlreadyExistsException(string.Format(i18n.SubjectAlreadyExistsException, subjectDto.SubjectName));
            }

            _entities.Subjects.Add(new Subject {SubjectName = subjectDto.SubjectName});
            _entities.SaveChanges();
        }
    }
}
