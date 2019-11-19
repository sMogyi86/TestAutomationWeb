/* -------------------------------------------------------------------------------------------------
   Restricted - Copyright (C) Siemens Healthcare GmbH/Siemens Medical Solutions USA, Inc., 2019. All rights reserved
   ------------------------------------------------------------------------------------------------- */

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomationWeb
{
    class FirstPageOfFNRVK86
    {
        private readonly IWebDriver myWebDriver;
        private readonly string myUrl;

        public FirstPageOfFNRVK86(string url, IWebDriver webDriver)
        {
            myUrl = url ?? throw new ArgumentNullException(nameof(url));
            myWebDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        public void Navigate()
            => myWebDriver.Navigate().GoToUrl(myUrl);

        public string Title => myWebDriver.Title;

        public RadioButtonedDecorator Question_1
            => new RadioButtonedDecorator(GetQuestions().Single(q => q.Number == 1));

        public RadioButtonedDecorator Question_2
            => new RadioButtonedDecorator(GetQuestions().Single(q => q.Number == 2));

        public ListBoxedDecorator Question_3
            => new ListBoxedDecorator(GetQuestions().Single(q => q.Number == 3));

        public T GetQuestion<T>(int i) where T : QuestionDecorator, new()
        {
            //=> new T(GetQuestions().Single(q => q.Number == i));

            var v = new T();

            return v;
        }

        public bool TryGoNextPage()
            => false;

        public IEnumerable<Question> GetQuestions()
            => myWebDriver
            .FindElements(By.ClassName(@" question-fieldset"))
            .Select(c => new Question(c));
    }
}
