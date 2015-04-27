using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Business.Enums;

namespace Gradebook.Business.Public_Data_Contracts
{
    public class TeacherDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public UserType UserType { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsAdministrator { get; set; }
    }
}
