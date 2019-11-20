using System.Collections.Generic;

namespace TestAutomationWeb.Contract
{
    public interface IHaveOptions
    {
        IEnumerable<IOption> Options { get; }
    }
}
