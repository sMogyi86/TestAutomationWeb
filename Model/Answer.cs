using OpenQA.Selenium;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal abstract class Answer : WebElement, IAnswer
    {
        protected readonly Question myQuestion;

        public Answer(IWebElement container, Question question) : base(container) { myQuestion = question; }

        public abstract string AnswerText { get; }
    }
}
