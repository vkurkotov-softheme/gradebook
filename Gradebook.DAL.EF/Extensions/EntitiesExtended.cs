using System.Linq;

namespace Gradebook.DAL.EF
{
    public partial class Entities
    {
        public IQueryable<Pupil> Pupils
        {
            get { return Users.OfType<Pupil>(); }
        } 
        public IQueryable<Teacher> Teachers
        {
            get { return Users.OfType<Teacher>(); }
        } 
        public IQueryable<Parent> Parents
        {
            get { return Users.OfType<Parent>(); }
        } 
    }
}
