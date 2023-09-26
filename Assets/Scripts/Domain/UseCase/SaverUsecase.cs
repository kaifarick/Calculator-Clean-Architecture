
using System;
using UnityEngine;

public class SaverUsecase : ISaverUsecase
{
    private const string DATA_KEY = "dataKey";

    private IExpressionDbGateway _expressionDbGateway;
    

    public SaverUsecase(IExpressionDbGateway expressionDbGateway)
    {
        _expressionDbGateway = expressionDbGateway;
        
        LoadData();
    }

    public void SaveData()
    {
        var expression = _expressionDbGateway.GetExpression();
        PlayerPrefs.SetString(DATA_KEY,expression);
    }

    public void LoadData()
    {
        var expression = PlayerPrefs.GetString(DATA_KEY);
        _expressionDbGateway.SetExpression(expression);
    }
}
