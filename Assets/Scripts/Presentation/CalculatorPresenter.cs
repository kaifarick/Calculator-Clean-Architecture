using System;

public class CalculatorPresenter: ICalculatorPresenter, IDisposable
{
    private ICalculatorView _view;
    private ICounterUsecase _counterUsecase;
    private ISaverUsecase _saverUsecase;

    public CalculatorPresenter(ICounterUsecase counterUsecase, ISaverUsecase saverUsecase, ICalculatorView view)
    {
        _view = view;
        _counterUsecase = counterUsecase;
        _saverUsecase = saverUsecase;
        
        _view.OnExpressionChanged += UpdateExpression;
        _view.OnCalculatePressed += CalculateExpression;
        _counterUsecase.OnOperationCompleteAction += OnOperationComplete;
        
        string savedExpression = GetInitialExpression();
        _view.SetValueInField(savedExpression ?? string.Empty);
    }

    public void CalculateExpression()
    {
        _counterUsecase.CalculateExpression();
    }

    public void UpdateExpression(string enterExpression)
    {
        _counterUsecase.UpdateExpression(enterExpression);
        _saverUsecase.SaveData();
    }
    
    public string GetInitialExpression()
    {
        return _counterUsecase.GetExpression();
    }


    private void OnOperationComplete(string result)
    {
        _view.OnOperationComplete(result);
    }
    
    public void Dispose()
    { 
        _view.OnExpressionChanged -= UpdateExpression;
        _view.OnCalculatePressed -= CalculateExpression;
        _counterUsecase.OnOperationCompleteAction -= OnOperationComplete;
    }
}
