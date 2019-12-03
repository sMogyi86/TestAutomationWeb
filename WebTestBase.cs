using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TestAutomationWeb
{
    [Binding]    //[TestFixture]
    class WebTestBase
    {
        private IWebDriver myWebDriver;
        protected IWebDriver Driver
        {
            get { return myWebDriver; }
            set
            {
                myWebDriver?.Quit();
                myWebDriver = value;
            }
        }

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=hu");

            myWebDriver = new ChromeDriver(options);
        }

        [TearDown]
        public void TearDown()
            => myWebDriver?.Quit();


        public static string webDriver = "driver";

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--lang=hu");
            var driver = new ChromeDriver(options);
            ScenarioContext.Current.Add(webDriver, driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = ScenarioContext.Current.Get<IWebDriver>(webDriver); ;
            driver.Quit();
        }
    }
}