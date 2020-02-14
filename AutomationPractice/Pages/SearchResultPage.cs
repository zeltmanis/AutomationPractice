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

    public class SearchResultPage
    {
        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;

        public IWebElement HeadingCounter => Driver.FindElement(By.ClassName("heading-counter"));
        public IWebElement Image => Driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.left-block > div > a.product_img_link > img"));
        public IWebElement MoreButton => Driver.FindElement(By.CssSelector("#center_column > ul > li > div > div.right-block > div.button-container > a.button.lnk_view.btn.btn-default"));

        public void ClickMore()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(Image).Perform();
           Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#center_column > ul > li > div > div.right-block > div.button-container > a.button.lnk_view.btn.btn-default")));
            MoreButton.Click();
        }

    }
}
