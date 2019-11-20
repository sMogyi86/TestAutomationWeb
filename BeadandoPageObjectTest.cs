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
            // assert title

            var question_1 = currentPage.GetQuestion<RadioButtonedDecorator>(1);
            // Hány előadó lenne optimális ebből a modulból?
            // assert options number (4)
            // 0 1 2 10
            question_1.Options.ElementAt(3).Choose();

            var question_2 = currentPage.GetQuestion<RadioButtonedDecorator>(2);
            // Mennyi időt biztosítottunk a gyakorlati feladatok megoldására?
            // assert options number (5)
            // Túl sokat, Sokat, Pont eleget, Keveset, Nagyon keveset
            question_2.Options.ElementAt(2).Choose();

            var question_3 = currentPage.GetQuestion<ListBoxedDecorator>(3);
            // Mivel foglalkoztál volna többet
            // assert options number
            // Webdriver basics, Webdriver advanced, Page Object, Data driven testing (DDT), Specflow, 
            question_3.Options.ElementAt(1).Choose();

            var question_4 = currentPage.GetQuestion<RankableDecorator>(4);
            // Rangsorold a témákat aszerint, hogy mennyire érdekelt.
            // assert options number
            // Webdriver basics, Webdriver advanced, Page Object, Data driven testing (DDT), Specflow, 
            question_4.Options.ElementAt(4).Rank = 0;

            currentPage.Next();

            var question_5 = currentPage.GetQuestion<RadioButtonedDecorator>(5);
            // assert Milyen nehéznek értékeled az órai feladatokat?
            // assert options number
            // Túl nehéz, Nehéz, 
            question_5.Options.ElementAt(4);

            var question_6 = currentPage.GetQuestion<TextAreadDecorator>(6);
            //  Egyéb javaslatok, megjegyzések
            question_6.Options.Single();

            //currentPage.Done();
            // assert title
        }
    }
}