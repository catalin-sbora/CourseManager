using CourseManager.ApplicationLogic.Abstractions;
using CourseManager.ApplicationLogic.DataModel;
using CourseManager.ApplicationLogic.Exceptions;
using CourseManager.ApplicationLogic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.ApplicationLogic.Tests.Services
{

    [TestClass]
    public class TeachersServiceTests
    {
        private Mock<ITeacherRepository> teacherRepoMock = new Mock<ITeacherRepository>();
        private Mock<ICourseRepository> courseRepoMock = new Mock<ICourseRepository>();
        private Guid existingUserId = Guid.Parse("7299FFCC-435E-4A6D-99DF-57A4D6FBA712");
        

        [TestInitialize]
        public void InitializeTest()
        {    
            

            var teacher = new Teacher
            {
                Id = existingUserId,
                Email = "blabla@mail.com",
                FirstName = "BlaBla",
                LastName = "LastBlaBla",
                PhoneNo = "0039947888474",
                UserId = existingUserId
            };

            teacherRepoMock.Setup(teacherRepo => teacherRepo.GetTeacherByUserId(existingUserId))
                            .Returns(teacher);
            
        }

        [TestMethod]
        public void GetTeacherByUserId_ThrowsException_WhenUserIdHasInvalidValue()
        {
            //arrange
            //ITeacherRepository teacherRepository, ICourseRepository
            var teacherService = new TeachersService(teacherRepoMock.Object, courseRepoMock.Object);

            var badUserId = "jkajsdkasj dkj daksdj as";
            //act            
            //assert
            Assert.ThrowsException<Exception>(() => {
                teacherService.GetTeacherByUserId(badUserId);
            });
        }

        [TestMethod]
        public void GetTeacherByUserId_ThrowsEntityNotFound_WhenUserDoesNotExist()
        {
            //arrange
            var nonExistingUserId = "7299FFCC-435E-4A6D-99DF-57A4D6FBA747";                                                   
            var teacherService = new TeachersService(teacherRepoMock.Object, courseRepoMock.Object);            
            
            //act            
            //assert
            Assert.ThrowsException<EntityNotFoundException>(() => {
                teacherService.GetTeacherByUserId(nonExistingUserId);
            });
        }

        [TestMethod]
        public void GetTeacherByUserId_Returns_UserWhenExists()
        {
           
            Exception throwException = null;
            var teacherService = new TeachersService(teacherRepoMock.Object, courseRepoMock.Object);
            Teacher user = null; 
            //act   
            try
            {
                user = teacherService.GetTeacherByUserId(existingUserId.ToString());
            }
            catch (Exception e)
            {
                throwException = e;
            }
            //assert
            Assert.IsNull(throwException, $"Exception was thrown");
            Assert.IsNotNull(user);
        }
    }
}
