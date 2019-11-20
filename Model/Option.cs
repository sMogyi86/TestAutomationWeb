using OpenQA.Selenium;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal abstract class Option : Answer, IOption
    {
        public Option(IWebElement container, Question question) : base(container, question) { }

        public abstract void Choose();
        public abstract bool Choosed { get; }
    }
}