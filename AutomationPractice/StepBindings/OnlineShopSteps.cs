using AutomationPractice.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumSkeleton.Utils;
using System;
using System.IO;
using TechTalk.SpecFlow;


namespace AutomationPractice
{
    [Binding]
    public class OnlineShopSteps
    {
        IWebDriver Driver = ChromeDriverHandler.Driver;
        WebDriverWait Wait = ChromeDriverHandler.Wait;


        [Given(@"I am in Sign In page")]
        public void GivenIAmInSignInPage()
        {
            LandingPage landingPage = new LandingPage();
            AuthenticationPage signInPage = new AuthenticationPage();

            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Assert.IsTrue(Driver.Title.ToLower().Contains("my store"));
            Wait.Until(condition => condition.FindElement(By.ClassName("login")));
            landingPage.ClickSignIn();
            Wait.Until(condition => condition.FindElement(By.Id("SubmitCreate")));
            Assert.IsTrue(signInPage.IsVisible());

        }
        
        [When(@"I enter email in Create New Account section")]
        public void WhenIEnterEmailInCreateNewAccountSection()
        {
            AuthenticationPage signInPage = new AuthenticationPage();
            CreateAccountPage createAccountPage = new CreateAccountPage();
            signInPage.EnterEmail();
            signInPage.ClickCreateAccount();
            Wait.Until(condition => condition.FindElement(By.Id("customer_firstname")));
            Assert.IsTrue(createAccountPage.IsVisible());

        }
        
        [When(@"I enter valid account details")]
        public void WhenIEnterValidAccountDetails()
        {
            CreateAccountPage createAccountPage = new CreateAccountPage();
            createAccountPage.ChooseTitle();
            createAccountPage.EnterFirstName("John");
            createAccountPage.EnterLastName("Smith");
            createAccountPage.EnterPassword("password");
            createAccountPage.EnterAdressFirstName("John");
            createAccountPage.EnterAddressLastName("Smith");
            createAccountPage.EnterAddress("Hauser Blv 14");
            createAccountPage.EnterCity("Beverlly Hills");
            createAccountPage.ChooseState();
            createAccountPage.EnterZip("90210");
            createAccountPage.EnterMobilePhone("5550205");
            createAccountPage.EnterAlias("john.smith@hotmail.com");
        }
        
        [When(@"click on Register button")]
        public void WhenClickOnRegisterButton()
        {
            CreateAccountPage createAccountPage = new CreateAccountPage();
            MyAccountPage myAccountPage = new MyAccountPage();

            createAccountPage.ClickRegister();
            Wait.Until(condition => condition.FindElement(By.ClassName("icon-user")));
            Assert.IsTrue(myAccountPage.IsVisible());
        }
        
        [When(@"My Account page is opened")]
        public void WhenMyAccountPageIsOpened()
        {
            MyAccountPage myAccountPage = new MyAccountPage();
            Assert.IsTrue(myAccountPage.IsVisible());
            var NavigationStep = Driver.FindElement(By.ClassName("navigation_page")).Text;
            Assert.IsTrue(NavigationStep.Contains("My account"));
        }
        
        [When(@"I click on My Personal Information button")]
        public void WhenIClickOnMyPersonalInformationButton()
        {
            MyAccountPage myAccountPage = new MyAccountPage();
            myAccountPage.ClickMyPersonalInfo();
        }
        
        [Then(@"Your Personal Information page is opened")]
        public void ThenYourPersonalInformationPageIsOpened()
        {
            PersonalInfoPage personalInfoPage = new PersonalInfoPage();
            personalInfoPage.IsVisible();
        }
        
        [Then(@"correct personal information is displayed")]
        public void ThenCorrectPersonalInformationIsDisplayed()
        {
            //PersonalInfoPage personalInfoPage = new PersonalInfoPage();
            //CreateAccountPage createAccountPage = new CreateAccountPage();

            Wait.Until(condition => condition.FindElement(By.Id("firstname")));
            string FirstName = Driver.FindElement(By.Id("firstname")).GetAttribute("value");
            Assert.IsTrue(FirstName.Contains("John"));
            string LastName = Driver.FindElement(By.Id("lastname")).GetAttribute("value");
            Assert.IsTrue(LastName.Contains("Smith"));

        }

        [Given(@"I am in Landing page")]
        public void GivenIAmInLandingPage()
        {
            PersonalInfoPage personalInfoPage = new PersonalInfoPage();
            personalInfoPage.GoToLanding();
            Wait.Until(condition => condition.FindElement(By.Id("search_query_top")));

        }

        [When(@"I select Search menu")]
        public void WhenISelectSearchMenu()
        {
            LandingPage landingPage = new LandingPage();
            landingPage.SelectSearch();
        }

        [When(@"I enter ""(.*)""")]
        public void WhenIEnter(string p0)
        {
            LandingPage landingPage = new LandingPage();
            landingPage.EnterSearch(p0);
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            LandingPage landingPage = new LandingPage();
            landingPage.ClickSearchButton();
            Wait.Until(condition => condition.FindElement(By.ClassName("navigation_page")));
        }

        [When(@"only (.*) result is found")]
        public void WhenOnlyResultIsFound(int p0)
        {
            var SearchResult = Driver.FindElement(By.ClassName("heading-counter")).Text;
            Assert.IsTrue(SearchResult.Contains(p0+ " result has been found."));
        }

        [When(@"I select the item")]
        public void WhenISelectTheItem()
        {
            SearchResultPage searchResultPage = new SearchResultPage();
            searchResultPage.ClickMore();
            Wait.Until(condition => condition.FindElement(By.ClassName("exclusive")));
        }

        [When(@"item description and condition is displayed")]
        public void WhenItemDescriptionAndConditionIsDisplayed()
        {
            ShopItemPage shopItemPage = new ShopItemPage();
            Assert.IsTrue(shopItemPage.IsVisible());
        }

        [When(@"I change quantity to (.*)")]
        public void WhenIChangeQuantityTo(string p0)
        {
            ShopItemPage shopItemPage = new ShopItemPage();
            shopItemPage.SelectQuantity(p0);
        }

        [When(@"I set size to S")]
        public void WhenISetSizeToS()
        {
            ShopItemPage shopItemPage = new ShopItemPage();
            shopItemPage.SelectSize();
        }

        [When(@"I set color to White")]
        public void WhenISetColorToWhite()
        {

            ShopItemPage shopItemPage = new ShopItemPage();
            shopItemPage.SelectColor();
        }

        [When(@"I select Add to cart button")]
        public void WhenISelectAddToCartButton()
        {
            ShopItemPage shopItemPage = new ShopItemPage();
            AddToCartPopUp addToCartPopUp = new AddToCartPopUp();
            shopItemPage.AddToCart();

        }

        [When(@"item is successfully added to cart")]
        public void WhenItemIsSuccessfullyAddedToCart()
        {

            AddToCartPopUp addToCartPopUp = new AddToCartPopUp();
            Wait.Until(condition => condition.FindElement(By.XPath("//*[@id='layer_cart']")));


        }

        [When(@"I click on Proceed to checkout button")]
        public void WhenIClickOnProceedToCheckoutButton()
        {
            AddToCartPopUp addToCartPopUp = new AddToCartPopUp();
            addToCartPopUp.ClickProceed();

            //string Url = Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a")).GetAttribute("href");
            //Driver.Navigate().GoToUrl(Url);
            //Wait.Until(condition => condition.FindElement(By.Id("cart_title")));

        }

        [Then(@"Shopping cart summary page is opened")]
        public void ThenShoppingCartSummaryPageIsOpened()
        {
            var NavigationStep = Driver.FindElement(By.ClassName("cart_title")).Text;
            Assert.IsTrue(NavigationStep.Contains("Shopping-cart summary"));
        }

        [Then(@"correct description is specified")]
        public void ThenCorrectDescriptionIsSpecified()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"amount is correctly calculated")]
        public void ThenAmountIsCorrectlyCalculated()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Proceed to checkout button is visible")]
        public void ThenProceedToCheckoutButtonIsVisible()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
