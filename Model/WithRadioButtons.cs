using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal class WithRadioButtons : QuestionDecorator, IHaveAnswer, IHaveOptions<RadioButton>
    {
        public IEnumerable<RadioButton> Options
          => Question.Container
          .FindElements(By.ClassName(@"answer-option-cell"))
          .Select(c => new RadioButton(c, Question));

        public string TheGivenAnswer => Options.SingleOrDefault(rb => rb.Choosed)?.AnswerText;

    }
}