using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IExpressionDbGateway
{
    public void SetExpression(string expression);
    public string GetExpression();
}
