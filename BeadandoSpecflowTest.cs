using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TestAutomationWeb.Contract;
using TestAutomationWeb.Model;

namespace TestAutomationWeb
{
    [Binding]
    class BeadandoSpecflowTest : WebTestBase
    {
        private const string URL = @"https://www.surveymonkey.com/r/FNRVK86";

        private IPage myCurrentPage;
        private IHaveAnswer myCurrentQuestion;

        [Given(@"I open the survey's webpage")]
        public void GivenIOpenTheSurveySWebpage()
        {
            myCurrentPage = Page.StartNew(URL, null);
            StringAssert.Contains("Obuda2019OszBeadando", myCurrentPage.Title, "Page title failed!");
        }

        [When(@"Choose the first question")]
        public void WhenChooseTheFirstQuestion()
        {
            myCurrentQuestion = myCurrentPage.GetQuestion<WithRadioButtons>(1);
        }

        [When(@"I answer the first question with (.*)")]
        public void WhenIAnswerItWith(string choosenText)
        {
            WithRadioButtons question = (WithRadioButtons)myCurrentQuestion;

            var options = question.Options.ToList();

            var choosen = question.Options.Single(o => o.AnswerText == choosenText);
        }

        [Then(@"the UI shall react by changing the first answer to (.*)")]
        public void ThenTheUIShallReactByChangingTheAnswerTo(string choosenText)
        {
            Assert.AreEqual(choosenText, myCurrentQuestion.TheGivenAnswer, "Set choosen failed!");
        }
    }
}