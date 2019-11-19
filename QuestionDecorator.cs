using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationWeb
{
     abstract class QuestionDecorator
    {
        protected Question myQuestion;
        public QuestionDecorator(Question question)        { myQuestion = question; }

        public abstract IEnumerable<Option> GetOptions();
    }

    class RadioButtonedDecorator : QuestionDecorator
    {
        public RadioButtonedDecorator(Question question)
            : base(question)
        { }

        public override IEnumerable<Option> GetOptions()
           => myQuestion.Container
           .FindElements(By.ClassName(@"answer-option-cell"))
           .Select(c => new RadioButton(c));
    }

    class ListBoxedDecorator : QuestionDecorator
    {
        public ListBoxedDecorator(Question question) : base(question) { }

        public override IEnumerable<Option> GetOptions()
            => myQuestion.Container
            .FindElements(By.TagName("option"))
            .Select(c => new ListElement(c));

    }
}
