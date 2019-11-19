using OpenQA.Selenium;

namespace TestAutomationWeb
{
    abstract class Widget
    {
        protected readonly IWebElement myContainer;

        public Widget(IWebElement container)
        {
            myContainer = container;
        }
    }

    class Question : Widget
    {
        private IWebElement LegendContainer => myContainer.FindElement(By.ClassName(@"question-legend"));
        public string Text => LegendContainer.FindElement(By.ClassName(@"user-generated"))?.Text;
        public int Number => int.Parse(LegendContainer.FindElement(By.ClassName(@"question-number")).Text.Trim().TrimEnd('.'));
        //public bool IsRequired => null != myContainer.FindElement(By.ClassName(@"question-validation-icon"));
        internal IWebElement Container => myContainer;

        public Question(IWebElement container) : base(container) { }
    }
}