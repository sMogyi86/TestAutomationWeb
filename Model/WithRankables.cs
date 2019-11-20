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
            myOffsetPlus = myOptionContainerHeight / 4;
        }

        public IEnumerable<Rankable> Rankables
              => Question.Container.FindElements(By.ClassName(@"question-ranking-rank-wrapper"))
                        .Select((c, i) => new Rankable(c, this, i));

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
