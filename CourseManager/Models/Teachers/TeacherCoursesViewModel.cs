using CourseManager.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManager.Models.Teachers
{
    public class TeacherCoursesViewModel
    {
        public Teacher Teacher { get; set; }
        public IEnumerable<Course> Courses {get; set;}
    }
}
