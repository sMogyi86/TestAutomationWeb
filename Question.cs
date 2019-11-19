using OpenQA.Selenium;

namespace TestAutomationWeb
{
    abstract class WebElement
    {
        internal IWebElement Container { get; private set; }

        public WebElement(IWebElement container)
        {
            Container = container;
        }
    }

    class Question : WebElement
    {
        private IWebElement LegendContainer => base.Container.FindElement(By.ClassName(@"question-legend"));
        public string Text => LegendContainer.FindElement(By.ClassName(@"user-generated"))?.Text;
        public int Number => int.Parse(LegendContainer.FindElement(By.ClassName(@"question-number")).Text.Trim().TrimEnd('.'));
        //public bool IsRequired => null != myContainer.FindElement(By.ClassName(@"question-validation-icon"));

        public Question(IWebElement container) : base(container) { }
    }
}