using System.Text.RegularExpressions;

public class AdditionOnlyEvaluator : IExpressionEvaluator
{
    public bool TryEvaluate(string expression, out long result)
    {
        result = 0;
        var match = Regex.Match(expression, @"^(\d+)\+(\d+)$");
        if (!match.Success) return false;

        try
        {
            var left = long.Parse(match.Groups[1].Value);
            var right = long.Parse(match.Groups[2].Value);
            result = left + right;
            return true;
        }
        catch
        {
            return false;
        }
    }
}