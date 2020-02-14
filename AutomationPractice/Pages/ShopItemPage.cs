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

    public class ShopItemPage
    {

        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;

        public IWebElement Condition => Driver.FindElement(By.Id("product_condition"));
        public IWebElement Description => Driver.FindElement(By.Id("short_description_block"));
        public IWebElement Quantity => Driver.FindElement(By.Id("quantity_wanted"));
        public IWebElement SizeDropDown => Driver.FindElement(By.CssSelector("#group_1"));
        public IWebElement Size => Driver.FindElement(By.CssSelector("#group_1 > option:nth-child(1)"));
        public IWebElement Color => Driver.FindElement(By.Id("color_8"));
        public IWebElement AddToCartButton => Driver.FindElement(By.Name("Submit"));


        public bool IsVisible()
        {
            return Condition.Displayed &&
                Description.Displayed;
        }

        public void SelectQuantity(string number)
        {
            Quantity.Click();
            Quantity.Clear();
            Quantity.SendKeys(number);
        }

        public void SelectSize()
        {
            SizeDropDown.Click();
            Wait.Until(condition => condition.FindElement(By.Id("uniform-group_1")));
            Size.Click();
        }

        public void SelectColor()
        {
            Color.Click();

        }

        public void AddToCart()
        {
            AddToCartButton.Click();
        }

    }
}
