

public class CalculatorPresenter: ICalculatorPresenter
{
    
    private ICounterUsecase _counterUsecase;
    private ISaverUsecase _saverUsecase;

    private CalculatorView _calculatorView;
    
    public CalculatorPresenter(ICounterUsecase counterUsecase, ISaverUsecase saverUsecase)
    {
        _counterUsecase = counterUsecase;
        _saverUsecase = saverUsecase;

        counterUsecase.OnOperationCompleteAction += OnOperationComplete;
    }

    public void Initialize(CalculatorView calculatorView)
    {
        _calculatorView = calculatorView;
        
        _calculatorView.OnUpdateExpressionAction += UpdateExpression;
        _calculatorView.OnResultButtonClickAction += SetResult;
        
        _calculatorView.Initialize(_counterUsecase.GetExpression());
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


    private void OnOperationComplete(string result)
    {
        _calculatorView.OnOperationComplete(result);
    }
    
}
