using OpenQA.Selenium;

namespace TestAutomationWeb.Model
{
    internal class RadioButton : Option
    {
        public RadioButton(IWebElement container, Question question) : base(container, question) { }

        public override string AnswerText => Container.FindElement(By.ClassName(@"radio-button-label-text"))?.Text?.Trim();

        public override void Choose() => Container.Click();

        public override bool Choosed => Container.FindElement(By.TagName("label")).GetAttribute("class").EndsWith("checked");
    }
}