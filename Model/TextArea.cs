using OpenQA.Selenium;

namespace TestAutomationWeb.Model
{
    internal class TextArea : Answer
    {
        public TextArea(IWebElement container, Question question) : base(container, question) { }

        public override string AnswerText => Container.GetAttribute("value");

        public void SetAnswer(string answer) => Container.SendKeys(answer);
    }
}