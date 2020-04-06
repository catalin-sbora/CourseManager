using CourseManager.ApplicationLogic.Abstractions;
using CourseManager.ApplicationLogic.DataModel;
using CourseManager.ApplicationLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseManager.ApplicationLogic.Services
{
    public class TeachersService
    {
        private ITeacherRepository teacherRepository;
        private ICourseRepository courseRepository;

        public TeachersService(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
        }

        public Teacher GetTeacherByUserId(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            var teacher = teacherRepository.GetTeacherByUserId(userIdGuid);
            if (teacher == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }

            return teacher;
        }
        
        public IEnumerable<Course> GetTeacherCourses(string userId)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }

            return courseRepository.GetAll()
                            .Where(course => course.Teacher != null && course.Teacher.UserId == userIdGuid)
                            .AsEnumerable();
        }

        public void AddCourse(string userId, string courseName, string courseDescription)
        {
            Guid userIdGuid = Guid.Empty;
            if (!Guid.TryParse(userId, out userIdGuid))
            {
                throw new Exception("Invalid Guid Format");
            }
            var teacher = teacherRepository.GetTeacherByUserId(userIdGuid);
            if (teacher == null)
            {
                throw new EntityNotFoundException(userIdGuid);
            }
            courseRepository.Add(new Course() { Id = Guid.NewGuid(), Teacher = teacher, Name = courseName, Description = courseDescription });
        }
    }
}
