using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using TestAutomationWeb.Contract;
using TestAutomationWeb.Model;

namespace TestAutomationWeb
{
    class Page
    {
        private readonly IWebDriver myWebDriver;
        private readonly string myUrl;

        private Page(string url, IWebDriver webDriver)
        {
            myUrl = url ?? throw new ArgumentNullException(nameof(url));
            myWebDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        private void NavigateToUrl()
            => myWebDriver.Navigate().GoToUrl(myUrl);

        public static Page StartNew(string url, IWebDriver webDriver)
        {
            var p = new Page(url, webDriver);

            p.NavigateToUrl();

            return p;
        }

        public string Title => myWebDriver.Title;

        public T GetQuestion<T>(int nth) where T : QuestionDecorator, new()
        {
            T decorator = new T();
            decorator.Question = GetQuestions().Single(q => q.Number == nth);

            decorator.WebDriver = myWebDriver;

            decorator.Initialize();
            return decorator;
        }

        public IEnumerable<Question> GetQuestions()
            => myWebDriver
            .FindElements(By.ClassName(@" question-fieldset"))
            .Select(c => new Question(c));

        public bool Next()
        {
            GetButton(nameof(Next))?.Click();

            return !myWebDriver.FindElements(By.ClassName("question-validation-theme")).Any();
        }

        public void Prev() => GetButton(nameof(Prev))?.Click();

        public bool Done()
        {
            GetButton(nameof(Done))?.Click();

            return !myWebDriver.FindElements(By.ClassName("question-validation-theme")).Any();
        }

        private IWebElement GetButton(string text)
            => myWebDriver
            .FindElement(By.ClassName(@"survey-submit-actions"))
            .FindElements(By.TagName("button"))
            .Where(b => b.Text.Trim() == text)
            .SingleOrDefault();
    }
}