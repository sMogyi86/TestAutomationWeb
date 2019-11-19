using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationWeb
{
    class BeadandoPageObjectTest : WebTestBase
    {
        private const string URL = @"https://www.surveymonkey.com/r/FNRVK86";

        [Test]
        public void NeedCreditsVeryMuch()
        {
            var firstPage = new FirstPageOfFNRVK86(URL, Driver);
            firstPage.Navigate();

            var question_1 = firstPage.GetQuestion<RadioButtonedDecorator>(1);

            var question_2 = firstPage.GetQuestion<RadioButtonedDecorator>(2);
            
            var question_3 = firstPage.GetQuestion<ListBoxedDecorator>(3);
            question_3.Options.ElementAt(1).Choose();

            var question_4 = firstPage.GetQuestion<RankableDecorator>(4);

            question_4.Options.ElementAt(4).Rank = 0;
            question_4.Options.ElementAt(0).Rank = 1;
            question_4.Options.ElementAt(4).Rank = 3;
            question_4.Options.ElementAt(2).Rank = 4;
        }
    }
}