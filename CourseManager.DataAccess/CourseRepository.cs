using CourseManager.ApplicationLogic.Abstractions;
using CourseManager.ApplicationLogic.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseManager.DataAccess
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(CourseManagerDbContext dbContext) : base(dbContext)
        { 
        }

        public CourseGrade GetStudentGrade(Guid courseId, Student student)
        {
            CourseGrade courseGrade = null;
            var selectedCourse = dbContext.Courses
                                          .Where(course => course.Id == courseId)
                                          .SingleOrDefault();
            if (selectedCourse != null)
            {
                courseGrade = selectedCourse.CourseGrades
                              .Where(grade => grade.Student.Id == student.Id)
                              .SingleOrDefault();
            }

            return courseGrade;
        }
    }
}
