using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomationWeb.Model
{
    internal class ListElement : Option
    {
        public override string AnswerText => Container.Text?.Trim();

        public override void Choose() => new SelectElement(ParentSelect).SelectByText(this.AnswerText);
        public override bool Choosed => new SelectElement(ParentSelect).SelectedOption.Text.Trim() == AnswerText;

        private IWebElement ParentSelect => Container.FindElement(By.XPath("./.."));
    }
}