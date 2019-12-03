namespace TestAutomationWeb.Contract
{
    interface IHaveAnswer: IQuestion
    {
        string TheGivenAnswer { get; }
    }
}