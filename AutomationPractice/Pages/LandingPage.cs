using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

using SeleniumExtras.WaitHelpers;
using SeleniumSkeleton.Utils;

namespace AutomationPractice.Pages
{

    public class LandingPage
    {

        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;

            public IWebElement SignInButton => Driver.FindElement(By.ClassName("login"));
        public IWebElement SearchBox => Driver.FindElement(By.Id("search_query_top"));
        public IWebElement SearchButton => Driver.FindElement(By.Name("submit_search"));


            public bool IsVisible()
            {
            return SignInButton.Displayed &&
            SearchBox.Displayed;
            }

            public void ClickSignIn()
            {
                SignInButton.Click();
            }

        public void SelectSearch()
        {
            SearchBox.Click();
            SearchBox.Clear();
        }

        public void EnterSearch(string text)
        {
            SearchBox.SendKeys(text);
        }

        public void ClickSearchButton()
        {
            SearchButton.Click();
        }
        

      

    }
}
