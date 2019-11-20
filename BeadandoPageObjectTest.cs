using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TestAutomationWeb.Model;

namespace TestAutomationWeb
{
    class BeadandoPageObjectTest : WebTestBase
    {
        private const string URL = @"https://www.surveymonkey.com/r/FNRVK86";

        [Test]
        public void NeedCreditsVeryMuch()
        {
            var currentPage = Page.StartNew(URL, Driver);
            StringAssert.Contains("Obuda2019OszBeadando", currentPage.Title);

            //#region 1
            //var question_1 = currentPage.GetQuestion<RadioButtonedDecorator>(1);
            //StringAssert.AreEqualIgnoringCase(@"Hány előadó lenne optimális ebből a modulból?", question_1.Text);

            //var q1options = question_1.Options.ToList();
            //Assert.AreEqual(4, q1options.Count);

            //var expectedOptions = new string[] { "0", "1", "2", "10" };
            //CollectionAssert.AreEqual(expectedOptions, q1options.Select(rb => rb.Answer));

            //var q1choosen = question_1.Options.ElementAt(3);
            //q1choosen.Choose();
            //Assert.AreEqual(q1choosen.Answer, question_1.TheChoosenOne.Answer);            
            //#endregion

            //#region 2
            //var question_2 = currentPage.GetQuestion<RadioButtonedDecorator>(2);
            //StringAssert.AreEqualIgnoringCase(@"Mennyi időt biztosítottunk a gyakorlati feladatok megoldására?", question_2.Text);

            //var q2options = question_2.Options.ToList();
            //Assert.AreEqual(5, q2options.Count);


            //// Túl sokat, Sokat, Pont eleget, Keveset, Nagyon keveset
            //question_2.Options.ElementAt(2).Choose();

            //#endregion 

            //var question_3 = currentPage.GetQuestion<ListBoxedDecorator>(3);
            //// Mivel foglalkoztál volna többet
            //// assert options number
            //// Webdriver basics, Webdriver advanced, Page Object, Data driven testing (DDT), Specflow, 
            //question_3.Options.ElementAt(1).Choose();

            //var question_4 = currentPage.GetQuestion<RankableDecorator>(4);
            //// Rangsorold a témákat aszerint, hogy mennyire érdekelt.
            //// assert options number
            //// Webdriver basics, Webdriver advanced, Page Object, Data driven testing (DDT), Specflow, 
            //question_4.Options.ElementAt(4).Rank = 0;

            //currentPage.Next();

            //var question_5 = currentPage.GetQuestion<RadioButtonedDecorator>(5);
            //// assert Milyen nehéznek értékeled az órai feladatokat?
            //// assert options number
            //// Túl nehéz, Nehéz, 
            //question_5.Options.ElementAt(4);

            //var question_6 = currentPage.GetQuestion<TextAreadDecorator>(6);
            ////  Egyéb javaslatok, megjegyzések
            //question_6.Options.Single();

            ////currentPage.Done();
            //// assert title
        }

        //private void TestWithOptions(IQuestion question)
        //{
        //    StringAssert.AreEqualIgnoringCase(@"Hány előadó lenne optimális ebből a modulból?", question.Text);

        //    var options = question.Options.ToList();
        //    Assert.AreEqual(4, options.Count);

        //    var expectedOptions = new string[] { "0", "1", "2", "10" };
        //    CollectionAssert.AreEqual(expectedOptions, options.Select(rb => rb.Answer));

        //    var choosen = question.Options.ElementAt(3);
        //    choosen.Choose();
        //    Assert.AreEqual(choosen.Answer, question.TheChoosenOne.Answer);
        //}
    }
}