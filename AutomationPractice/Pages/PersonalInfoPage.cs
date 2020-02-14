using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

using SeleniumExtras.WaitHelpers;
using SeleniumSkeleton.Utils;
using System;
using AutomationPractice.Utils;

namespace AutomationPractice.Pages
{
    public class PersonalInfoPage
    {


        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;

        public IWebElement FirstName => Driver.FindElement(By.Id("firstname"));
        public IWebElement LastName => Driver.FindElement(By.Id("lastname"));
        public IWebElement Logo => Driver.FindElement(By.Id("header_logo"));


        public bool IsVisible()
        {
            return FirstName.Displayed &&
                LastName.Displayed;
        }

        public void GoToLanding()
        {
            Logo.Click();
        }

    }
}
