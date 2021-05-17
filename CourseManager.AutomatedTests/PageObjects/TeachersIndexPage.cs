using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.AutomatedTests.PageObjects
{
    class TeachersIndexPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.CssSelector, Using ="main")]
        private IWebElement coursesList;
        
        [FindsBy(How= How.LinkText, Using = "Add Course")]
        private IWebElement addCourseButton;
       
         public TeachersIndexPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void GoToPage()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44379/Teacher");
        }
        public AddCoursePage GotoAddCoursePage()
        {
            addCourseButton.Click();
            return new AddCoursePage(webDriver);
        }

        public bool CourseExists(string courseName)
        {
            var elements = coursesList.FindElements(By.TagName("div"));
            return elements.Where(element => element.Text.Equals(courseName)).Count() > 0;
            
        }

    }
}
