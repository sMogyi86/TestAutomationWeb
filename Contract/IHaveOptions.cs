using System.Collections.Generic;

namespace TestAutomationWeb.Contract
{
    public interface IHaveOptions<T> where T: IOption
    {
        IEnumerable<T> Options { get; }
    }
}
