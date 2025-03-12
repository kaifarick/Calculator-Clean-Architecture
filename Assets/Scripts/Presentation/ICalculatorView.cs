using System;

public interface ICalculatorView
{
    event Action<string> OnExpressionChanged;
    event Action OnCalculatePressed;

    void SetValueInField(string result);
    void OnOperationComplete(string result);
}
