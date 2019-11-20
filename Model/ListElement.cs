using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationWeb.Model
{
    internal class ListElement : Option
    {
        public ListElement(IWebElement container, Question question) : base(container, question) { }

        public override string AnswerText => Container.Text?.Trim();

        //public override void Choose() => new SelectElement(myQuestion.Container.FindElement(By.TagName("select"))).SelectByText(this.AnswerText);
        public override void Choose() => new SelectElement(ParentSelect).SelectByText(this.AnswerText);
        public override bool Choosed => new SelectElement(ParentSelect).SelectedOption.Text.Trim() == AnswerText;

        private IWebElement ParentSelect => myQuestion.Container.FindElement(By.XPath("./.."));
    }
}