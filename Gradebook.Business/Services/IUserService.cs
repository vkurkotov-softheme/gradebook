using System.Collections.Generic;
using Gradebook.Business.Enums;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;

namespace Gradebook.Business.Services
{
    public interface IUserService
    {
        Pupil CreatePupil(PupilDto pupil) ;

        Teacher CreateTeacher(TeacherDto teacher);

        bool ValidateUser(string email, string password);

        User GetUser(string email);

        void UpdateLastLoginTime(User user);

        UserType GetUserType(string email);

        IEnumerable<Teacher> GetTeachers();

        void AddTeacher(TeacherDto teacherDto);
    }
}
