using System;
using System.Data.Entity.Core;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Gradebook.Business.Enums;
using Gradebook.Business.Exceptions;
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

            var passwordHash = MD5Helper.GetPasswordHash(password);

            var user = _entities.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);

            return user != null;
        }

        public User GetUser(string email)
        {
            AssertHelper.AssertNotNull(email, "email", "email field is not passed");

            var user = _entities.Users.FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new UserNotFoundException(string.Format(i18n.UserNotFoundException, email));
            }

            return user;
        }

        public void UpdateLastLoginTime(User user)
        {
            user.LastLogin = DateTime.UtcNow;
            _entities.SaveChanges();
        }

        public UserType GetUserType(string email)
        {
            if (_entities.Teachers.Any(t => t.Email == email))
            {
                var user = _entities.Teachers.FirstOrDefault(t => t.Email == email);
                AssertHelper.AssertNotNull(user, "user", string.Format(i18n.UserNotFoundException, email));

                return user.IsAdministrator ? UserType.Administrator : UserType.Teacher;
            }

            if (_entities.Pupils.Any(p => p.Email == email))
            {
                return UserType.Pupil;
            }

            if (_entities.Parents.Any(p => p.Email == email))
            {
                return UserType.Parent;
            }

            throw new UserNotFoundException(string.Format(i18n.UserNotFoundException, email));
        }
    }
}
