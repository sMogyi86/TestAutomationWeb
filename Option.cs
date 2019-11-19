using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestAutomationWeb
{
    abstract class Option : Widget
    {
        public Option(IWebElement container)
            : base(container)
        { }

        public abstract string Answer { get; }

        public void Choose()
            => myContainer.Click();
    }

    class RadioButton : Option
    {
        public RadioButton(IWebElement container) : base(container) { }

        public override string Answer => myContainer.FindElement(By.ClassName(@"radio-button-label-text"))?.Text;
    }

    class ListElement : Option
    {
        public ListElement(IWebElement container) : base(container) { }

        public override string Answer => myContainer.Text;
    }
}
