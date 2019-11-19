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

        public T GetQuestion<T>(int nth) where T : QuestionDecorator, new()
        {
            var qd = new T();

            qd.Question = GetQuestions().Single(q => q.Number == nth);
            qd.WebDriver = myWebDriver;

            return qd;
        }

        public bool TryGoNextPage()
            => false;

        public IEnumerable<Question> GetQuestions()
            => myWebDriver
            .FindElements(By.ClassName(@" question-fieldset"))
            .Select(c => new Question(c));
    }
}
