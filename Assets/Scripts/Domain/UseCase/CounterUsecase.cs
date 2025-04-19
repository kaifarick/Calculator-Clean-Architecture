using System;

public class CounterUsecase : ICounterUsecase
{
    private readonly IExpressionRepository _gateway;
    private readonly IExpressionEvaluator _evaluator;

    public event Action<string> OnOperationCompleteAction;

    public CounterUsecase(IExpressionRepository gateway, IExpressionEvaluator evaluator)
    {
        _gateway = gateway;
        _evaluator = evaluator;
    }

    public void CalculateExpression()
    {
        var stringExp = _gateway.GetExpression();
        if (string.IsNullOrEmpty(stringExp)) return;

        if (_evaluator.TryEvaluate(stringExp, out var result))
        {
            var newResultString = $"{stringExp}={result}";
            OnOperationCompleteAction?.Invoke(newResultString);
        }
        else
        {
            OnOperationCompleteAction?.Invoke($"{stringExp}=ERROR");
        }
    }

    public void UpdateExpression(string enterExpression)
    {
        _gateway.SetExpression(enterExpression);
    }

    public string GetExpression()
    {
        return _gateway.GetExpression();
    }
}