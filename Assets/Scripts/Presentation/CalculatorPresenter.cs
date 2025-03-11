using System;

public class CalculatorPresenter: ICalculatorPresenter
{
    
    private ICounterUsecase _counterUsecase;
    private ISaverUsecase _saverUsecase;

    public event Action<string> OnOperationCompleteAction;
    
    private bool _disposed = false;

    public CalculatorPresenter(ICounterUsecase counterUsecase, ISaverUsecase saverUsecase)
    {
        _counterUsecase = counterUsecase;
        _saverUsecase = saverUsecase;

        counterUsecase.OnOperationCompleteAction += OnOperationComplete;
    }


    public void SetResult()
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
        OnOperationCompleteAction?.Invoke(result);
    }
    
    public void Dispose()
    {
        if (!_disposed)
        {
            _counterUsecase.OnOperationCompleteAction -= OnOperationComplete;
            _disposed = true;
        }
    }
    
}
