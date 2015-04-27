using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.DAL.EF;

namespace Gradebook.Business.Public_Data_Contracts
{
    public class PupilDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string ResidentalAdress { get; set; }
        public string RegisteredAdress { get; set; }
        public string Phone { get; set; }
        public string HomePhone { get; set; }
        public bool Deleted { get; set; }
        public int Role { get; set; }

        public Grade Grade { get; set; }
    }
}
