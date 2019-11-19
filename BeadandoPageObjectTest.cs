using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationWeb
{
    class BeadandoPageObjectTest :WebTestBase
    {
        private const string URL = @"https://www.surveymonkey.com/r/FNRVK86";

        [Test]
        public void NeedCreditsVeryMuch()
        {
            var firstPage = new FirstPageOfFNRVK86(URL, Driver);

            firstPage.Navigate();

        }
        // Create FNRVK86_FirstPage
    }
}
