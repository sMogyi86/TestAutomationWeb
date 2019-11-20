using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal class WithListBoxes : QuestionDecorator, IHaveAnswer, IHaveOptions<ListElement>
    {
        public IEnumerable<ListElement> Options
           => Question.Container
           .FindElements(By.TagName("option"))
           .Select(c => new ListElement(c, Question));

        public string TheGivenAnswer => Options.SingleOrDefault(le => le.Choosed)?.AnswerText;
    }
}
