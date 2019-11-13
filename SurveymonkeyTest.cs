
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
            StringAssert.Contains("Obuda2019OszBeadando", Driver.Title);

            var questionFieldsets = Driver.FindElements(By.ClassName(@" question-fieldset"));
            Assert.AreEqual(4, questionFieldsets.Count);

            foreach (var fieldset in questionFieldsets)
            {
                var qLegend = fieldset.FindElement(By.ClassName(@"question-legend"));
                var questionbody = fieldset.FindElement(By.ClassName(@"question-body"));

                var qNumber = qLegend.FindElement(By.ClassName(@"question-number"));
                var number = int.Parse(qNumber.Text.Trim().TrimEnd('.'));

                var qText = qLegend.FindElement(By.ClassName(@"user-generated"));
                var question = qText.Text;

                switch (number)
                {
                    case 1:
                        this.Answer_First(question, questionbody);
                        break;

                    case 2:
                        this.Answer_Second(question, questionbody);
                        break;

                    case 3:
                        this.Answer_Third(question, questionbody);
                        break;

                    case 4:
                        this.Answer_Fourth(question, questionbody);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            //StringAssert.Contains("Thank you! Create Your Own Online Survey Now!", Driver.Title);
        }

        private void Answer_First(string question, IWebElement questionbody, Predicate<string> choose)
        {
            StringAssert.AreEqualIgnoringCase(@"Hány előadó lenne optimális ebből a modulból?", question);

            var answeOptionCells = questionbody.FindElements(By.ClassName(@"answer-option-cell"));
            var answeOptions = answeOptionCells
                                .Select(c => new { Text = c.FindElement(By.ClassName("radio-button-label-text"))?.Text, Container = c })
                                .ToList();
            Assert.AreEqual(4, answeOptions.Count);
            CollectionAssert.AreEqual()
            // 0 1 2 10

            foreach (var kvp in answeOptions)
                this.ChooseThisOption(kvp.Container, choose(kvp.Text));
        }

        private void Answer_Second(string question, IWebElement questionbody)
        {
            StringAssert.AreEqualIgnoringCase(@"Mennyi időt biztosítottunk a gyakorlati feladatok megoldására?", question);
        }

        private void Answer_Third(string question, IWebElement questionbody)
        {
            StringAssert.AreEqualIgnoringCase(@"Mivel foglalkoztál volna többet", question);
        }

        private void Answer_Fourth(string question, IWebElement questionbody)
        {
            StringAssert.AreEqualIgnoringCase(@"Rangsorold a témákat aszerint, hogy mennyire érdekelt.", question);
        }

        private void ChooseThisOption(IWebElement webElement, bool choose)
        {
            if (choose)
                webElement.Click();
        }
    }
}
