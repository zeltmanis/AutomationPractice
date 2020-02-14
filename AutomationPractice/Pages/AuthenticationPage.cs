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
    public class AuthenticationPage
    {

        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;




        
            public IWebElement EmailBox => Driver.FindElement(By.Id("email_create"));
            public IWebElement CreateAccountButton => Driver.FindElement(By.Id("SubmitCreate"));



            public bool IsVisible()
            {
                return EmailBox.Displayed &&
                    CreateAccountButton.Displayed;
            }

            
            public void EnterEmail()
            {
            WordGenerator word = new WordGenerator();
                EmailBox.Click();
                EmailBox.Clear();
                EmailBox.SendKeys(word.GenerateString() + "@inbox.com");
            }

            public void ClickCreateAccount()
            {
                CreateAccountButton.Click();
            }

   



    }
}
