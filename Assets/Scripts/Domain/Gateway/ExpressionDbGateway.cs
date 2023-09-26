

public class ExpressionDbGateway : IExpressionDbGateway
{
    private Expression _expression;

    public ExpressionDbGateway()
    {
        _expression = new Expression();
    }

    public void SetExpression(string expression)
    {
        _expression.CurrentExpression = expression;
    }

    public string GetExpression()
    {
        return _expression.CurrentExpression;
    }
}
