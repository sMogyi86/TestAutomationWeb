using OpenQA.Selenium;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal abstract class Answer : WebElement, IAnswer
    {
        public Question Question { get; set; }

        public abstract string AnswerText { get; }
    }
}
