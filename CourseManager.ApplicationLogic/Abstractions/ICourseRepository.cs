using CourseManager.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.Abstractions
{
    public interface ICourseRepository: IRepository<Course>
    {
        CourseGrade GetStudentGrade(Guid courseId, Student student);
    }
}
