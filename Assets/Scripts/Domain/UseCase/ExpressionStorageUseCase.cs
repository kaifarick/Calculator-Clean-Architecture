public class ExpressionStorageUseCase : ISaverUsecase
{
    private const string DATA_KEY = "EXPRESSION_SAVE";

    private IExpressionRepository _expressionRepository;
    private readonly IDataStorage _dataStorage;
    
    public ExpressionStorageUseCase(IExpressionRepository expressionRepository, IDataStorage dataStorage)
    {
        _expressionRepository = expressionRepository;
        _dataStorage = dataStorage;
        LoadData();
    }

    public void SaveData()
    {
        var expression = _expressionRepository.GetExpression();
        _dataStorage.Save(DATA_KEY, expression);
    }

    public void LoadData()
    {
        if (_dataStorage.HasKey(DATA_KEY))
        {
            var expression = _dataStorage.Load(DATA_KEY);
            _expressionRepository.SetExpression(expression);
        }
    }
}
