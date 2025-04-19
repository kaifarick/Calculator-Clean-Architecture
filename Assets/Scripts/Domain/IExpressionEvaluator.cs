public interface IExpressionEvaluator
{
    bool TryEvaluate(string expression, out long result);
}