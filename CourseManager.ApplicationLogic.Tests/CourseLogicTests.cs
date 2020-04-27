using CourseManager.ApplicationLogic.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CourseManager.ApplicationLogic.Tests
{
    [TestClass]
    public class CourseLogicTests
    {
        [TestMethod]
        public void GetStudentsWithAverageGradeGreaterThan_Returns_OnlyStudentsWithAverageGradesGT()
        {
            //Arrange
            Course course = new Course() 
                            { 
                                Id = Guid.NewGuid(),
                                Name = "Test Course",
                                Description = "Test Course Description",
                                Teacher = new Teacher 
                                {
                                    Id = Guid.NewGuid(),
                                    FirstName = "Teacher First",
                                    LastName = "Teacher Last",
                                    Email = "mail@mail.com"
                                }                                
            };

            var firstStudentId = Guid.NewGuid();
            var secondStudentId = Guid.NewGuid();
            var thirdStudentId = Guid.NewGuid();
            var forthStudentId = Guid.NewGuid();
            var fifthStudentId = Guid.NewGuid();

            List<Student> students = new List<Student>
                                     {
                                       new Student {Id= firstStudentId, Email = "student1@mail.com", FirstName="FistStudentFirstName", LastName="FirstStudentLastName" },
                                       new Student {Id= secondStudentId, Email = "student2@mail.com", FirstName="SecondStudentFirstName", LastName="SecondStudentLastName" },
                                       new Student {Id= thirdStudentId, Email = "student3@mail.com", FirstName="ThirdStudentFirstName", LastName="ThirdStudentLastName" },
                                       new Student {Id= forthStudentId, Email = "student4@mail.com", FirstName="ForthStudentFirstName", LastName="ForthStudentLastName" },
                                       new Student {Id= fifthStudentId, Email = "student5@mail.com", FirstName="FifthStudentFirstName", LastName="FifthStudentLastName" }
                                     };
            foreach(var student in students)
                course.Students.Add(student);

            course.CourseGrades.Add(new CourseGrade() { Student = students[0], Date = DateTime.Now, GradeValue = 5, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[0], Date = DateTime.Now, GradeValue = 7, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[0], Date = DateTime.Now, GradeValue = 6, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[0], Date = DateTime.Now, GradeValue = 8, Id = Guid.NewGuid() });

            course.CourseGrades.Add(new CourseGrade() { Student = students[1], Date = DateTime.Now, GradeValue = 5, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[1], Date = DateTime.Now, GradeValue = 7, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[1], Date = DateTime.Now, GradeValue = 6, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[1], Date = DateTime.Now, GradeValue = 8, Id = Guid.NewGuid() });

            course.CourseGrades.Add(new CourseGrade() { Student = students[2], Date = DateTime.Now, GradeValue = 5, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[2], Date = DateTime.Now, GradeValue = 7, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[2], Date = DateTime.Now, GradeValue = 6, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[2], Date = DateTime.Now, GradeValue = 8, Id = Guid.NewGuid() });

            course.CourseGrades.Add(new CourseGrade() { Student = students[3], Date = DateTime.Now, GradeValue = 5, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[3], Date = DateTime.Now, GradeValue = 7, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[3], Date = DateTime.Now, GradeValue = 6, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[3], Date = DateTime.Now, GradeValue = 8, Id = Guid.NewGuid() });

            course.CourseGrades.Add(new CourseGrade() { Student = students[4], Date = DateTime.Now, GradeValue = 9, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[4], Date = DateTime.Now, GradeValue = 9, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[4], Date = DateTime.Now, GradeValue = 9, Id = Guid.NewGuid() });
            course.CourseGrades.Add(new CourseGrade() { Student = students[4], Date = DateTime.Now, GradeValue = 9, Id = Guid.NewGuid() });


            //Act
            var retList = course.GetStudentsWithAverageGradeGreaterThan(8);

            //Assert            
            Assert.AreEqual(1, retList.Count);
            var collectionEnum = retList.GetEnumerator();
            collectionEnum.MoveNext();
            Assert.AreEqual(fifthStudentId, collectionEnum.Current.Id);
        }
    }
}
