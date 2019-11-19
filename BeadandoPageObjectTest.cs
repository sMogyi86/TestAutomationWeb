using NUnit.Framework;
using System.Linq;

namespace TestAutomationWeb
{
    class BeadandoPageObjectTest : WebTestBase
    {
        private const string URL = @"https://www.surveymonkey.com/r/FNRVK86";

        [Test]
        public void NeedCreditsVeryMuch()
        {
            var currentPage = Page.StartNew(URL, Driver);

            var question_1 = currentPage.GetQuestion<RadioButtonedDecorator>(1);
            question_1.Options.ElementAt(3).Choose();

            var question_2 = currentPage.GetQuestion<RadioButtonedDecorator>(2);
            question_2.Options.ElementAt(2).Choose();

            var question_3 = currentPage.GetQuestion<ListBoxedDecorator>(3);
            question_3.Options.ElementAt(1).Choose();

            var question_4 = currentPage.GetQuestion<RankableDecorator>(4);
            question_4.Options.ElementAt(4).Rank = 0;

            currentPage.Next();

            var question_5 = currentPage.GetQuestion<RadioButtonedDecorator>(5);
            question_5.Options.ElementAt(4);

            /*
            while (!currentPage.Next()) { }
            currentPage.Prev();
            while (!currentPage.Next()) { }
            while (!currentPage.Done()) { }
            */
        }
    }
}