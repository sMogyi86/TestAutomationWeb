using OpenQA.Selenium;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal abstract class QuestionDecorator : IQuestion
    {
        public int Number => Question.Number;
        public string QuestionText => Question.QuestionText;

        public Question Question { get; set; }
        public IWebDriver WebDriver { get; set; }

        public virtual void Initialize() { }
    }
}
