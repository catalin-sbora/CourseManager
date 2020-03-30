using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.DataModel
{
    public class CourseGrade
    {
        public Guid Id { get; set; }
        public Student Student { get; set; }
        public double GradeValue { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
    }
}
