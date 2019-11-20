using OpenQA.Selenium;

namespace TestAutomationWeb.Model
{
    internal class Rankable : Answer
    {
        private IChangeRank myChangeRank;

        public Rankable(IWebElement container, WithRankables decorator, int initialRank)
        {
            base.Container = container;
            base.Question = decorator.Question;

            myChangeRank = decorator;
            myRank = initialRank;
        }

        public override string AnswerText => Container.FindElement(By.ClassName(@"question-body-font-theme")).Text.Trim();

        private int myRank;
        public int Rank
        {
            get { return myRank; }
            set
            {
                myChangeRank.Move(this, value);
                myRank = value;
            }
        }
    }
}
