//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gradebook.DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher : User
    {
        public Teacher()
        {
            this.Marks = new HashSet<Mark>();
            this.Lessons = new HashSet<LessonShedule>();
            this.Subjects = new HashSet<Subject>();
        }
    
        public string JobTitle { get; set; }
        public Nullable<bool> IsAdministrator { get; set; }
    
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<LessonShedule> Lessons { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
