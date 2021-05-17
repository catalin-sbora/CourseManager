using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.AutomatedTests.PageObjects
{
    class AddCoursePage
    {
        private IWebDriver webDriver;

        [FindsBy(How=How.Id, Using ="Name")]
        private IWebElement courseName;

        [FindsBy(How = How.Id, Using = "Description")]
        private IWebElement courseDescription;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/form/div[3]/div[2]/button")]
        private IWebElement saveButton;
        public AddCoursePage(IWebDriver driver)
        {
            this.webDriver = driver;            
            PageFactory.InitElements(driver, this);
        }

        public void Save(string courseName, string courseDescription)
        {
            this.courseName.Clear();
            this.courseName.SendKeys(courseName);
            this.courseDescription.Clear();
            this.courseDescription.SendKeys(courseDescription);
            saveButton.Click();
        }
    }
}
