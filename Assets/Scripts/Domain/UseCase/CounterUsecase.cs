using System;
using System.Linq;

public class CounterUsecase : ICounterUsecase
{
    private  char[] _allowedCharacters = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '+'};

    private IExpressionDbGateway _gateway;

    public event Action<string> OnOperationCompleteAction;
    
    public CounterUsecase(IExpressionDbGateway gateway)
    {
        _gateway = gateway;
    }
    

    public void CalculateExpression()
    {
        var stringExp = _gateway.GetExpression();
        //stringExp = stringExp.Replace(" ", "");
        if(string.IsNullOrEmpty(stringExp)) return;

        if (stringExp.All(c => _allowedCharacters.Contains(c)) && stringExp.Contains("+") && !stringExp.Contains("++"))
        {
            var result = stringExp.Split('+').Select(s => Convert.ToInt32(s)).Sum();
            var newResultString = $"{stringExp}={result}";
            
            OnOperationCompleteAction?.Invoke(newResultString);
        }
        else
        {
            var newResultString = $"{stringExp}=ERROR";
            OnOperationCompleteAction?.Invoke(newResultString);
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
