using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace TestAutomationWeb.Model
{
    internal class WithRankables : QuestionDecorator, IChangeRank
    {
        private int myOptionContainerHeight;
        private int myOffsetPlus;

        public override void Initialize()
        {
            base.Initialize();

            myOptionContainerHeight = Rankables.First().Container.Size.Height;
            myOffsetPlus = myOptionContainerHeight / 3;
        }

        public IEnumerable<Rankable> Rankables
              => Question.Container.FindElements(By.ClassName(@"question-ranking-rank-wrapper"))
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
}
