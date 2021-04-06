using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Project2_Group_4.Expressions
{
    class ExpressionEvaluation
    {
        private static string Evaluate(double left, double right, string operand)
        {
            var leftNode = Expression.Constant(left);
            var rightNode = Expression.Constant(right);
            switch (operand)
            {
                case "+":
                    var additionExpression = Expression.Add(leftNode, rightNode);
                    return Expression.Lambda<Func<double>>(additionExpression).Compile()().ToString();
                case "-":
                    var subtractionExpression = Expression.Subtract(leftNode, rightNode);
                    return Expression.Lambda<Func<double>>(subtractionExpression).Compile()().ToString();
                case "*":
                    var multiplyExpression = Expression.Multiply(leftNode, rightNode);
                    return Expression.Lambda<Func<double>>(multiplyExpression).Compile()().ToString();
                case "/":
                    var divideExpression = Expression.Divide(leftNode, rightNode);
                    return Expression.Lambda<Func<double>>(divideExpression).Compile()().ToString();
                default:
                    return "ERROR: Operand does not exist.";
            }
        }
        public static IEnumerable<string> PostFixEvaluate(IEnumerable<string> postFixDataSet)
        {
            try
            {
                foreach (var postFixData in postFixDataSet)
                {
                    Stack<string> stack = new Stack<string>();
                    string answer;
                    for (int j = 0; j < postFixData.Length; j++)
                    {
                        string c = postFixData.Substring(j, 1);
                        if (!char.IsDigit(c[0]))
                        {
                            double rightNode = Convert.ToDouble(stack.Pop());
                            double leftNode = Convert.ToDouble(stack.Pop());
                            answer = Evaluate(leftNode, rightNode, c);
                            stack.Push(answer);
                        }
                        else
                        {
                            stack.Push(postFixData.Substring(j, 1));
                        }
                    }
                    yield return stack.Pop();
                }
            }
            finally
            {
                // Do nothing: this stops the iterator/yield
            }
        }

        public static IEnumerable<string> PreFixEvaluate(IEnumerable<string> preFixDataSet)
        {
            try
            {
                foreach (var preFixData in preFixDataSet)
                {
                    Stack<string> stack = new Stack<string>();
                    string answer;
                    for (int j = preFixData.Length - 1; j >= 0; j--)
                    {
                        // if operand push to stack
                        if (char.IsDigit(preFixData[j]))
                        {
                            stack.Push(preFixData[j].ToString());
                        }
                        else
                        {
                            double leftNode = Convert.ToDouble(stack.Pop());
                            double rightNode = Convert.ToDouble(stack.Pop());

                            answer = Evaluate(leftNode, rightNode, preFixData[j].ToString());
                            stack.Push(answer);
                        }
                    }
                    yield return stack.Pop();
                }
            }
            finally
            {
                // Do nothing: this stops the iterator/yield
            }
        }
    }
}
