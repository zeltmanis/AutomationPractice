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
using OpenQA.Selenium.Interactions;


namespace AutomationPractice.Pages
{

    public class ShopCartSummaryPage
    {
        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;

        public IWebElement Title => Driver.FindElement(By.Id("cart_title"));

        public bool IsVisible()
        {
            return 
                Title.Displayed;
        }
    }

}
