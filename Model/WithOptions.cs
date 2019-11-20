using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal abstract class WithOptions<T> : QuestionDecorator, IWithOptions where T : Option, new()
    {
        protected abstract string ClassName { get; }

        public IEnumerable<IOption> Options
           => Question.Container
            .FindElement(By.ClassName("question-body"))
           .FindElements(By.ClassName(ClassName))
           .Select(c => new T() { Container = c, Question = Question });

        public string TheGivenAnswer => Options.SingleOrDefault(o => o.Choosed)?.AnswerText;
    }
}