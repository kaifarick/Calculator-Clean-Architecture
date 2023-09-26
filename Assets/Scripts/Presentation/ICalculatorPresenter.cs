
using System;

public interface ICalculatorPresenter
{
    public void SetResult();
    public void UpdateExpression(string enterExpression);
    public void Initialize(CalculatorView calculatorView);
}
