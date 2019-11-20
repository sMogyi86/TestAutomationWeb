﻿using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TestAutomationWeb.Contract;
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
            StringAssert.Contains("Obuda2019OszBeadando", currentPage.Title, "Page title failed!");

            TestWithOptions(currentPage.GetQuestion<WithRadioButtons>(1), new Expected()
            {
                Choosen = "2",
                Options = new string[] { "0", "1", "2", "10" },
                Text = @"Hány előadó lenne optimális ebből a modulból?"
            });

            TestWithOptions(currentPage.GetQuestion<WithRadioButtons>(2), new Expected()
            {
                Choosen = "Pont eleget",
                Options = new string[] { "Túl sokat", "Sokat", "Pont eleget", "Keveset", "Nagyon keveset" },
                Text = @"Mennyi időt biztosítottunk a gyakorlati feladatok megoldására?"
            });

            TestWithOptions(currentPage.GetQuestion<WithListBox>(3), new Expected()
            {
                Choosen = "Webdriver advanced",
                Options = new string[] { "Webdriver basics", "Webdriver advanced", "Page Object", "Data driven testing (DDT)", "Specflow" },
                Text = @"Mivel foglalkoztál volna többet"
            });

            #region 4
            var q4 = currentPage.GetQuestion<WithRankables>(4);
            StringAssert.AreEqualIgnoringCase("Rangsorold a témákat aszerint, hogy mennyire érdekelt.", q4.QuestionText, "Question text failed!");

            var rankables = q4.Rankables;
            Assert.AreEqual(5, rankables.Count(), "Options count failed!");

            var expectedRankables = new string[] { "Webdirver basics", "Webdriver advanced", "Page Object", "Data driven testing (DDT)", "Specflow", };
            CollectionAssert.AreEqual(expectedRankables, rankables.Select(r => r.AnswerText), "Options compare failed!");

            rankables.Single(r => r.AnswerText == "Webdriver advanced").Rank = 3;
            #endregion

            Assert.IsTrue(currentPage.Next(), "Go next page failed!");

            TestWithOptions(currentPage.GetQuestion<WithRadioButtons>(5), new Expected()
            {
                Choosen = "Pont jó",
                Options = new string[] { "Túl nehéz", "Nehéz", "Pont jó", "Könnyű", "Túl könnyű" },
                Text = @"Milyen nehéznek értékeled az órai feladatokat?"
            });

            #region 6
            var q6 = currentPage.GetQuestion<WithTextArea>(6);
            StringAssert.AreEqualIgnoringCase("Egyéb javaslatok, megjegyzések", q6.QuestionText, "Question text failed!");

            var expectedNotes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis id sapien convallis, ullamcorper tellus id, fringilla lectus. Vestibulum id odio et metus porttitor accumsan nec pulvinar eros. Ut nec turpis tempus, auctor nisl eget, eleifend leo. Aliquam sagittis mauris at sollicitudin imperdiet. Ut sed faucibus libero, luctus maximus lorem. Vestibulum sit amet eros turpis. Nulla tincidunt libero ligula, vel sollicitudin ex finibus quis. Quisque tincidunt velit ac ipsum mollis, vitae congue sapien convallis. Sed quis bibendum enim. Aenean dapibus leo et mauris vestibulum pulvinar. Vestibulum viverra massa sit amet diam consequat, vitae varius dui placerat. Donec feugiat nulla faucibus velit pellentesque aliquet. Ut eget nibh ut risus egestas vehicula et ac orci.";
            q6.TextArea.SetAnswer(expectedNotes);
            StringAssert.AreEqualIgnoringCase(expectedNotes, q6.TheGivenAnswer, "Set answer text failed!");
            #endregion

            Assert.IsTrue(currentPage.Done(), "Submit survey failed!");
            StringAssert.Contains("Thank you! Create Your Own Online Survey Now!", currentPage.Title, "Page final title failed!");
        }

        private void TestWithOptions(IWithOptions question, Expected expected)
        {
            StringAssert.AreEqualIgnoringCase(expected.Text, question.QuestionText, "Question text failed!");

            var options = question.Options.ToList();
            Assert.AreEqual(expected.OptionsCount, options.Count, "Options count failed!");

            CollectionAssert.AreEqual(expected.Options, options.Select(o => o.AnswerText), "Options compare failed!");

            var choosen = question.Options.Single(o => o.AnswerText == expected.Choosen);
            choosen.Choose();
            Assert.AreEqual(expected.Choosen, question.TheGivenAnswer, "Set choosen failed!");
        }

        private class Expected
        {
            public string Text { get; set; }
            public int OptionsCount => Options.Count();
            public IEnumerable<string> Options { get; set; }
            public string Choosen { get; set; }
        }
    }
}