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
using System.Linq;

namespace AutomationPractice.Pages
{

    public class AddToCartPopUp
    {

        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;

        public IWebElement ProceedPopUp=> Driver.FindElement(By.XPath("//*[@id='layer_cart']"));
        public IWebElement ProceedButton => Driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[3]/div/div/div[4]/div[1]/div[2]/div[4]/a"));

        public bool IsVisible()
        {
            return
                ProceedPopUp.Displayed;
        }

        public void ClickProceed()
        {
            //Driver.SwitchTo().Window(Driver.WindowHandles.Last());
            ProceedButton.Click();
        }


    }
}
