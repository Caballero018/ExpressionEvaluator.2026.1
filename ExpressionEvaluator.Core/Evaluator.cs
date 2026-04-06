namespace ExpressionEvaluator.Core;

using System.Globalization;

public class Evaluator
{
    public static double Evaluate(string infix)
    {
        var postfix = InfixToPostfix(infix);
        return EvaluatePostfix(postfix);
    }

    private static string InfixToPostfix(string infix)
    {
        var postFix = new List<string>();
        var stack = new Stack<char>();
        foreach (var item in Tokenize(infix))
        {
            if (item.Length == 1 && IsOperator(item[0]))
            {
                var currentOperator = item[0];

                if (currentOperator == '(')
                {
                    stack.Push(currentOperator);
                    continue;
                }

                if (currentOperator == ')')
                {
                    while (stack.Count > 0 && stack.Peek() != '(')
                    {
                        postFix.Add(stack.Pop().ToString());
                    }

                    if (stack.Count == 0 || stack.Peek() != '(')
                    {
                        throw new Exception("Sintax error.");
                    }

                    stack.Pop();
                    continue;
                }

                if (stack.Count == 0)
                {
                    stack.Push(currentOperator);
                }
                else
                {
                    while (stack.Count > 0 && PriorityInfix(currentOperator) <= PriorityStack(stack.Peek()))
                    {
                        postFix.Add(stack.Pop().ToString());
                    }

                    stack.Push(currentOperator);
                }
            }
            else
            {
                postFix.Add(item);
            }
        }

        while (stack.Count > 0)
        {
            var item = stack.Pop();
            if (item == '(')
            {
                throw new Exception("Sintax error.");
            }

            postFix.Add(item.ToString());
        }

        return string.Join(' ', postFix);
    }

    private static int PriorityStack(char item) => item switch
    {
        '^' => 3,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 0,
        _ => throw new Exception("Sintax error."),
    };

    private static int PriorityInfix(char item) => item switch
    {
        '^' => 4,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 5,
        _ => throw new Exception("Sintax error."),
    };

    private static double EvaluatePostfix(string postfix)
    {
        var stack = new Stack<double>();
        foreach (var item in postfix.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (item.Length == 1 && IsOperator(item[0]))
            {
                var b = stack.Pop();
                var a = stack.Pop();
                stack.Push(item[0] switch
                {
                    '+' => a + b,
                    '-' => a - b,
                    '*' => a * b,
                    '/' => a / b,
                    '^' => Math.Pow(a, b),
                    _ => throw new Exception("Sintax error."),
                });
            }
            else
            {
                stack.Push(ParseNumber(item));
            }
        }

        return stack.Pop();
    }

    private static bool IsOperator(char item) => "+-*/^()".Contains(item);

    private static IEnumerable<string> Tokenize(string infix)
    {
        var currentNumber = string.Empty;

        foreach (var item in infix.Replace(',', '.'))
        {
            if (char.IsWhiteSpace(item))
            {
                continue;
            }

            if (char.IsDigit(item) || item == '.')
            {
                currentNumber += item;
                continue;
            }

            if (currentNumber.Length > 0)
            {
                yield return currentNumber;
                currentNumber = string.Empty;
            }

            if (!IsOperator(item))
            {
                throw new Exception("Sintax error.");
            }

            yield return item.ToString();
        }

        if (currentNumber.Length > 0)
        {
            yield return currentNumber;
        }
    }

    private static double ParseNumber(string item)
    {
        if (double.TryParse(item, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
        {
            return result;
        }

        throw new Exception("Sintax error.");
    }
}
