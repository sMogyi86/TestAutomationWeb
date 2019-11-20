using OpenQA.Selenium;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal class WithTextArea : QuestionDecorator, IHaveAnswer
    {
        public TextArea TextArea => new TextArea(Question.Container.FindElement(By.TagName("textarea")), Question);

        public string TheGivenAnswer => TextArea.AnswerText;
    }
}
