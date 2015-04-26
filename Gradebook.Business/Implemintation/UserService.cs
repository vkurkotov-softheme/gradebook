using System;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                PasswordHash = GetPasswordHash(teacher.Password)
            };

            _entities.Users.Add(newTeacher);
            _entities.SaveChanges();

            return newTeacher;
        }

        private string GetPasswordHash(string password)
        {
            using (var hasher = MD5.Create())
            {
                byte[] data = hasher.ComputeHash(Encoding.Default.GetBytes(password));
                var hash = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    hash.Append(data[i].ToString("x2", CultureInfo.InvariantCulture));
                }

                return hash.ToString();
            }
        }
    }
}
