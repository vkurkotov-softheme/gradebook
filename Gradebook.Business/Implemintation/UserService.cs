using System;
using System.Data.Entity.Core;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Gradebook.Business.Helpers;
using Gradebook.Business.Interfaces;
using Gradebook.Business.Public_Data_Contracts;
using Gradebook.DAL.EF;
using Gradebook.Translations;

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

            //_entities.Users.Add(newUser);
            //_entities.SaveChanges();
            return newUser;
        }

        public Teacher CreateTeacher(TeacherDto teacher)
        {
            var newTeacher = new Teacher
            {
                FirstName = teacher.FirstName,
                Email = teacher.Email,
                BirthDate = teacher.BirthDate,
                IsAdministrator = teacher.IsAdministrator,
                LastName = teacher.LastName,
                MiddleName = teacher.MiddleName,
                PasswordHash = MD5Helper.GetPasswordHash(teacher.Password)
            };

            _entities.Users.Add(newTeacher);
            _entities.SaveChanges();

            return newTeacher;
        }

        public bool ValidateUser(string email, string password)
        {
            AssertHelper.AssertNotNull(email, "email", "email field is not passed");
            AssertHelper.AssertNotNull(password, "password", "password field is not passed");

            var user = _entities.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == MD5Helper.GetPasswordHash(password));

            return user != null;
        }

        public User GetUser(string email)
        {
            AssertHelper.AssertNotNull(email, "email", "email field is not passed");

            var user = _entities.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new ObjectNotFoundException(string.Format(i18n.UserNotFoundException, email));
            }

            return user;
        }

        public void UpdateLastLoginTime(User user)
        {
            user.LastLogin = DateTime.UtcNow;
            _entities.SaveChanges();
        }
    }
}
