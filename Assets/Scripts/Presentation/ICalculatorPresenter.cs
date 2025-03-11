
using System;

public interface ICalculatorPresenter
{ 
    public event Action<string> OnOperationCompleteAction;
    public void SetResult();
    public void UpdateExpression(string enterExpression);
    public string GetInitialExpression();
}
