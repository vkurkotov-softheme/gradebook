using Gradebook.Business.Enums;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;

namespace Gradebook.Business.Interfaces
{
    public interface IUserService
    {
        Pupil CreatePupil(PupilDto pupil) ;

        Teacher CreateTeacher(TeacherDto teacher);

        bool ValidateUser(string email, string password);

        User GetUser(string email);

        void UpdateLastLoginTime(User user);
        UserType GetUserType(string email);
    }
}
