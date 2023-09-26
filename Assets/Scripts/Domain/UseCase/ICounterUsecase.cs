
using System;

public interface ICounterUsecase
{
    public event Action<string> OnOperationCompleteAction;
    public void CalculateExpression();
    public void UpdateExpression(string enterExpression);
    public string GetExpression();
}
