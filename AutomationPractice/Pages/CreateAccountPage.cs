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
  
    public class CreateAccountPage
    {
        protected IWebDriver Driver = ChromeDriverHandler.Driver;
        protected WebDriverWait Wait = ChromeDriverHandler.Wait;


        //Elements for "Your Personal Information"
        public IWebElement TitleMr => Driver.FindElement(By.Id("id_gender1"));
        public IWebElement FirstName => Driver.FindElement(By.Id("customer_firstname"));
        public IWebElement LastName => Driver.FindElement(By.Id("customer_lastname"));
        public IWebElement Password => Driver.FindElement(By.Id("passwd"));

        //Elements for "Your Address"
        public IWebElement AddressFirstName => Driver.FindElement(By.Id("firstname"));
        public IWebElement AddressLastName => Driver.FindElement(By.Id("lastname")); 
        public IWebElement Address=> Driver.FindElement(By.Id("address1"));
        public IWebElement City => Driver.FindElement(By.Id("city"));
        public IWebElement StateDropDown => Driver.FindElement(By.Id("id_state"));
        public IWebElement StateSelect => Driver.FindElement(By.XPath("//*[@id='id_state']//*[@value][5]"));
        public IWebElement Zip => Driver.FindElement(By.Id("postcode"));
        public IWebElement MobilePhone => Driver.FindElement(By.Id("phone_mobile"));
        public IWebElement Alias => Driver.FindElement(By.Id("alias"));
        public IWebElement RegisterButton => Driver.FindElement(By.Id("submitAccount"));

        public bool IsVisible()
        {
            return TitleMr.Displayed &&
                FirstName.Displayed &&
                LastName.Displayed &&
                Password.Displayed &&
                AddressFirstName.Displayed &&
                AddressLastName.Displayed &&
                City.Displayed;
                //StateDropDown.Displayed &&
                //Zip.Displayed &&
                //MobilePhone.Displayed &&
                //Alias.Displayed &&
                //RegisterButton.Displayed;
        }

        public void ChooseTitle()
        {
            TitleMr.Click();
        }

        public void EnterFirstName(string text)
        {
            FirstName.Click();
            FirstName.Clear();
            FirstName.SendKeys(text);
        }

        public void EnterLastName(string text)
        {
            LastName.Click();
            LastName.Clear();
            LastName.SendKeys(text);
        }

        public void EnterPassword(string text)
        {
            Password.Click();
            Password.Clear();
            Password.SendKeys(text);
        }

        public void EnterAdressFirstName(string text)
        {
            AddressFirstName.Click();
            AddressFirstName.Clear();
            AddressFirstName.SendKeys(text);
        }

        public void EnterAddressLastName(string text)
        {
            AddressLastName.Click();
            AddressLastName.Clear();
            AddressLastName.SendKeys(text);
        }

        public void EnterAddress(string text)
        {
            Address.Click();
            Address.Clear();
            Address.SendKeys(text);
        }

        public void EnterCity(string text)
        {
            City.Click();
            City.Clear();
            City.SendKeys(text);
        }

        public void ChooseState()
        {
            StateDropDown.Click();
            StateSelect.Click();
        }

        public void EnterZip(string text)
        {
            Zip.Click();
            Zip.Clear();
            Zip.SendKeys(text);
        }

        public void EnterMobilePhone(string text)
        {
            MobilePhone.Click();
            MobilePhone.Clear();
            MobilePhone.SendKeys(text);
        }

        public void EnterAlias(string text)
        {
            Alias.Click();
            Alias.Clear();
            Alias.SendKeys(text);
        }

        public void ClickRegister()
        {
            RegisterButton.Click();
        }

    }
}
