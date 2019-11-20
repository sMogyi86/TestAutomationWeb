using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationWeb
{
    abstract class Option : WebElement
    {
        protected readonly Question myQuestion;

        public Option(IWebElement container, Question question)
            : base(container)
        { myQuestion = question; }

        public abstract string Answer { get; }
    }

    class RadioButton : Option
    {
        public RadioButton(IWebElement container, Question question) : base(container, question) { }

        public override string Answer => Container.FindElement(By.ClassName(@"radio-button-label-text"))?.Text?.Trim();

        public void Choose() => Container.Click();
    }

    class ListElement : Option
    {
        public ListElement(IWebElement container, Question question) : base(container, question) { }

        public override string Answer => Container.Text?.Trim();

        public void Choose() => new SelectElement(myQuestion.Container.FindElement(By.TagName("select")))
                                .SelectByText(this.Answer);
    }

    class Rankable : Option
    {
        private IMove myMove;

        public Rankable(IWebElement container, RankableDecorator decorator, int initialRank)
            : base(container, decorator.Question)
        {
            myMove = decorator;
            myRank = initialRank;
        }

        public override string Answer => Container.FindElement(By.ClassName(@"question-body-font-theme"))?.Text?.Trim();

        private int myRank;
        public int Rank
        {
            get { return myRank; }
            set
            {
                myMove.Move(this, value);
                myRank = value;
            }
        }
    }

    class TextArea : Option
    {
        public TextArea(IWebElement container, Question question) : base(container, question)        {        }

        public override string Answer => Container.GetAttribute("value");

        public void SetAnswer(string answer)
            => Container.SendKeys(answer);
    }
}