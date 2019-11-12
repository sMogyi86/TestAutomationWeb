
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationWeb
{
    class SurveymonkeyTest : WebTestBase
    {
        private const string Url = @"https://www.surveymonkey.com/r/FNRVK86";

        [Test]
        public void NeedCredits()
        {
            Driver.Navigate().GoToUrl(Url);
            // ass title contains Obuda2019OszBeadando

            var questionFieldsets = Driver.FindElements(By.ClassName(@" question-fieldset"));
            // assert count 4

            foreach (var fieldset in questionFieldsets)
            {
                var qLegend = fieldset.FindElement(By.ClassName(@"question-legend"));
                var qNumber = qLegend.FindElement(By.ClassName(@"question-number"));
                var number = int.Parse(qNumber.Text.Trim().TrimEnd('.'));

                switch (number)
                {
                    case 1:
                        this.Answer_First(fieldset);
                        break;

                    case 2:
                        this.Answer_Second(fieldset);
                        break;

                    case 3:
                        this.Answer_Third(fieldset);
                        break;

                    case 4:
                        this.Answer_Fourth(fieldset);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        private void Answer_First(IWebElement fieldset)
        {
            //var radioButtonContainers = fieldset.FindElements(By.ClassName(@"radio-button-container "));
            // assert count 4
        }

        private void Answer_Second(IWebElement fieldset)
        {
        }

        private void Answer_Third(IWebElement fieldset)
        {
        }

        private void Answer_Fourth(IWebElement fieldset)
        {
        }
    }
}
