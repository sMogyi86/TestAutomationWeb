using OpenQA.Selenium;

namespace TestAutomationWeb.Model
{
    internal class TextArea : Answer
    {
        public TextArea(IWebElement container, Question question)
        {
            base.Container = container;
            base.Question = question;
        }

        public override string AnswerText => Container.GetAttribute("value");

        public void SetAnswer(string answer) => Container.SendKeys(answer);
    }
}