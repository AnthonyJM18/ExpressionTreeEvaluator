/* Group:       4
 * Programmers: Anthony Merante, Colin Manliclic, Zina Long
 * Date:        April 6, 2021
 * 
 * Purpose:     Class to evaluate prefix or postfix expressions
 */

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Project2_Group_4.Expressions
{
    class ExpressionEvaluation
    {
        /// <summary>
        /// Uses binary tree to evaluate a left node, right node and operator. 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="operatorString"></param>
        /// <returns>Returns evaluation of a left and right operand and operator string</returns>
        private static string Evaluate(double left, double right, string operatorString)
        {
            // operands
            var leftNode = Expression.Constant(left);
            var rightNode = Expression.Constant(right);

            // operator switch case
            switch (operatorString)
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
        /// <summary>
        /// Evaluates a data set of post fix expressions and returns a collection of the results
        /// </summary>
        /// <param name="postFixDataSet"></param>
        /// <returns>string IEnumerable of post fix results</returns>
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
                        // if beginning of post fix expression is not a digit
                        if (!char.IsDigit(postFixData[j]))
                        {
                            // pop stack to right and left node
                            double rightNode = Convert.ToDouble(stack.Pop());
                            double leftNode = Convert.ToDouble(stack.Pop());

                            // evaluate the answer and push to stack
                            answer = Evaluate(leftNode, rightNode, postFixData[j].ToString());
                            stack.Push(answer);
                        }
                        else
                        {
                            // just push to stack if it is a digit
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
        /// <summary>
        /// Evaluates a data set of prefix expressions and returns a collection of the results
        /// </summary>
        /// <param name="prefixDataSet"></param>
        /// <returns>string IEnumerable of prefix results</returns>
        public static IEnumerable<string> PrefixEvaluate(IEnumerable<string> prefixDataSet)
        {
            try
            {
                foreach (var prefixData in prefixDataSet)
                {
                    Stack<string> stack = new Stack<string>();
                    string answer;
                    for (int j = prefixData.Length - 1; j >= 0; j--)
                    {
                        // if operand push to stack
                        if (char.IsDigit(prefixData[j]))
                        {
                            stack.Push(prefixData[j].ToString());
                        }
                        else
                        {
                            // pop stack to get left and right node
                            double leftNode = Convert.ToDouble(stack.Pop());
                            double rightNode = Convert.ToDouble(stack.Pop());

                            // evaluate answer and push to stack
                            answer = Evaluate(leftNode, rightNode, prefixData[j].ToString());
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
