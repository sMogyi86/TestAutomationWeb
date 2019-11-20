using OpenQA.Selenium;

namespace TestAutomationWeb.Model
{
    internal abstract class WebElement
    {
        public IWebElement Container { get;  set; }
    }
}