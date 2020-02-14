using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

using SeleniumExtras.WaitHelpers;
using SeleniumSkeleton.Utils;
using System;

namespace AutomationPractice.Pages
{
    public class MyAccountPage
    {
        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;

        public IWebElement OrderHistory => Driver.FindElement(By.ClassName("icon-list-ol"));
        public IWebElement MyCredit => Driver.FindElement(By.ClassName("icon-ban-circle"));
        public IWebElement MyAddresses => Driver.FindElement(By.ClassName("icon-building"));
        public IWebElement MyPersonalInfoButton => Driver.FindElement(By.ClassName("icon-user"));
        public IWebElement MyWishLists => Driver.FindElement(By.ClassName("icon-heart"));

        public bool IsVisible()
        {
            return
                OrderHistory.Displayed &&
                MyCredit.Displayed &&
                MyAddresses.Displayed &&
                MyPersonalInfoButton.Displayed &&
                MyWishLists.Displayed;
        }

        public void ClickMyPersonalInfo()
        {
            MyPersonalInfoButton.Click();
        }

    }
}
