using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSkeleton.Utils
{
    //SpecFlow attributes are used to initiate and manage
    //browser windows and ChromeDriver session during tests
    [Binding]
    static class ChromeDriverHandler
    {
        public static IWebDriver Driver;
        public static ChromeOptions ChromeOptions;
        public static ChromeDriverService DriverService;
        public static WebDriverWait Wait;
        [BeforeTestRun(Order = 0)]
        static void StartService()
        {
            DriverService = ChromeDriverService.CreateDefaultService(AppContext.BaseDirectory);
            DriverService.Start();

            ChromeOptions = new ChromeOptions();
            //ChromeOptions.AddArgument("--headless");
           
        }
        [AfterTestRun]
        static void EndService()
        {
            DriverService.Dispose();
        }
        [BeforeScenario]
        static void StartDriver()
        {
            Driver = new RemoteWebDriver(DriverService.ServiceUrl, ChromeOptions);
            Wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
        }
        [AfterScenario]
        static void EndDriver()
        {
            TakeAScreenshot();
            Driver.Quit();
        }
        public static void TakeAScreenshot()
        {
            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(TestContext.CurrentContext.Test.Name + ".png");
        }
    }
}