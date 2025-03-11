

public class ExpressionRepository : IExpressionRepository
{
    private Expression _expression;

    public ExpressionRepository()
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
