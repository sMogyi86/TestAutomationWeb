using TestAutomationWeb.Contract;

namespace TestAutomationWeb.Model
{
    internal abstract class Option : Answer, IOption
    {
        public abstract void Choose();
        public abstract bool Choosed { get; }
    }
}