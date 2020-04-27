using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CourseManager.ApplicationLogic.DataModel
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Teacher Teacher {get; set;}
        public ICollection<Student> Students { get; private set; }
        public ICollection<CourseGrade> CourseGrades { get; private set; }
        public ICollection<CoursePresence> CoursePresences { get; private set; }

        public Course()
        {
            Students = new List<Student>();
            CourseGrades = new List<CourseGrade>();
            CoursePresences = new List<CoursePresence>();
        }
        public IReadOnlyCollection<Student> GetStudentsWithAverageGradeGreaterThan(double grade)
        {
            var studentsList = new List<Student>();
            foreach(var student in Students)
            {
                var average = CourseGrades
                               .Where(gr => gr.Student.Id == student.Id)
                               .Average(gr => gr.GradeValue);
                if (average > grade)
                {
                    studentsList.Add(student);
                }
            }
            return studentsList.AsReadOnly();                                       
        }
    }
}


