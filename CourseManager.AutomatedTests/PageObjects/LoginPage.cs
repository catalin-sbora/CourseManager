using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.AutomatedTests.PageObjects
{
    class LoginPage
    {
        private IWebDriver webDriver;

        [FindsBy(How = How.Id, Using = "Input_Email")]
        private IWebElement userNameTextBox;
        
        [FindsBy(How = How.Id, Using = "Input_Password")]
        private IWebElement passwordTextBox;
        
        [FindsBy(How = How.XPath, Using = "/html/body/div/main/div/div[1]/section/form/div[5]/button")]
        private IWebElement loginButton;
        
        public LoginPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Login(string userName, string password)
        {
            userNameTextBox.Clear();
            userNameTextBox.SendKeys(userName);
            passwordTextBox.Clear();
            passwordTextBox.SendKeys(password);
            loginButton.Click();
        }


    }
}
