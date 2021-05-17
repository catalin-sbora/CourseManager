using CourseManager.AutomatedTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CourseManager.AutomatedTests
{
    [TestClass]
    public class TeachersTest
    {
        private IWebDriver webDriver;

        [TestInitialize]
        public void InitTests()
        {
            webDriver = new ChromeDriver();
        }
        [TestMethod]
        public void TeachersAddCourse_Creates_CourseWithGivenName()
        {
            
            Random randomNumber = new Random();
            string courseName = "MyTestCourse " + randomNumber.Next(100, 10000000);
            HomePage homePage = new HomePage(webDriver);
            homePage.GoToPage();
            LoginPage loginPage = homePage.GoToLoginPage();
            loginPage.Login("catalin.sbora@gmail.com", "P@ssword1");

            TeachersIndexPage indexPage = new TeachersIndexPage(webDriver);
            indexPage.GoToPage();
            AddCoursePage addCoursePage = indexPage.GotoAddCoursePage();
            addCoursePage.Save(courseName, "My Test Course Desc");

            Assert.IsTrue(indexPage.CourseExists(courseName));

        }
        [TestCleanup]
        public void Cleanup()
        {
            webDriver.Close();
        }
    }
}
