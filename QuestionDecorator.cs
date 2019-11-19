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
        private Question myQuestion;
        internal Question Question
        {
            get { return myQuestion; }
            set
            {
                myQuestion = value ?? throw new ArgumentNullException(nameof(value));

                Initialize();
            }
        }

        internal IWebDriver WebDriver { get; set; }

        protected virtual void Initialize() { }
    }

    abstract class QuestionDecorator<T> : QuestionDecorator where T : Option
    {
        public abstract IEnumerable<T> Options { get; }
    }

    class RadioButtonedDecorator : QuestionDecorator<RadioButton>
    {
        public override IEnumerable<RadioButton> Options
           => Question.Container
           .FindElements(By.ClassName(@"answer-option-cell"))
           .Select(c => new RadioButton(c, Question));
    }

    class ListBoxedDecorator : QuestionDecorator<ListElement>
    {
        public override IEnumerable<ListElement> Options
            => Question.Container
            .FindElements(By.TagName("option"))
            .Select(c => new ListElement(c, Question));
    }

    class RankableDecorator : QuestionDecorator<Rankable>, IMove
    {
        private int myOptionContainerHeight;
        private int myOffsetPlus;

        protected override void Initialize()
        {
            base.Initialize();

            myOptionContainerHeight = Options.First().Container.Size.Height;
            myOffsetPlus = myOptionContainerHeight / 3;
        }

        public override IEnumerable<Rankable> Options
              => Question.Container
                        .FindElements(By.ClassName(@"question-ranking-rank-wrapper"))
                        .Select((c, i) => new Rankable(c, this, i));

        // https://www.google.com/search?q=selenium+DragAndDropToOffset&oq=selenium+DragAndDropToOffset&aqs=chrome..69i57j33.7112j0j7&sourceid=chrome&ie=UTF-8
        public void Move(Rankable item, int toRank)
        {
            int offset = toRank - item.Rank;

            if (offset != 0)
                new OpenQA.Selenium.Interactions.Actions(WebDriver)
                    .DragAndDropToOffset(item.Container, 0, myOptionContainerHeight * offset + (offset < 0 ? -myOffsetPlus : myOffsetPlus))
                    .Build().Perform();
        }
    }

    interface IMove
    {
        void Move(Rankable item, int toRank);
    }
}