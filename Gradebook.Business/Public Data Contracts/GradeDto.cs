using Gradebook.DAL.EF;

namespace Gradebook.Business.Public_Data_Contracts
{
    public class GradeDto
    {
        public string GradeName { get; set; }

        public short BeginYear { get; set; }

        public short GraduateYear { get; set; }

        public Teacher FormMaster { get; set; }
    }
}
