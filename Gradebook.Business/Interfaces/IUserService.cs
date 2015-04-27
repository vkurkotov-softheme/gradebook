using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;

namespace Gradebook.Business.Interfaces
{
    public interface IUserService
    {
        Pupil CreatePupil(PupilDto pupil) ;

        Teacher CreateTeacher(TeacherDto teacher);
    }
}
