using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.DataModel
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Teacher Teacher {get; set;}
        public ICollection<Student> Students { get; set; }
        public ICollection<CourseGrade> CourseGrades { get; private set; }

        public ICollection<CoursePresence> CoursePresences { get; private set; }
    }
}


