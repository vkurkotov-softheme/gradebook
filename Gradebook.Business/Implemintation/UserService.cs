using System.Linq;
using Gradebook.Business.Interfaces;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;

namespace Gradebook.Business.Implemintation
{
    public class UserService : IUserService
    {
        private readonly Entities _entities;

        public UserService(Entities entities)
        {
            _entities = entities;
        }

        public Pupil CreatePupil(PupilDto pupil)
        {
            var user = (Pupil)_entities.Users.FirstOrDefault(u => u.FirstName == pupil.FirstName);
            if (user != null)
            {
                return user;
            }

            var newUser = new Pupil
            {
                BirthDate = pupil.BirthDate,
                Grade = pupil.Grade
            };

            _entities.Users.Add(newUser);
            _entities.SaveChanges();
            return newUser;
        }
    }
}
