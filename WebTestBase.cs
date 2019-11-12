
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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