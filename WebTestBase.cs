using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestAutomationWeb
{
    [TestFixture]
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
    }
}