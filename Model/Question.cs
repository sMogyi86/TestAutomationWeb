using OpenQA.Selenium;
using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal class Question : WebElement, IQuestion
    {
        private IWebElement LegendContainer => Container.FindElement(By.ClassName(@"question-legend"));
        public string QuestionText => LegendContainer.FindElement(By.ClassName(@"user-generated"))?.Text;
        public int Number => int.Parse(LegendContainer.FindElement(By.ClassName(@"question-number")).Text.Trim().TrimEnd('.'));
    }
}