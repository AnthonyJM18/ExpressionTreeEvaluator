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
        public string EvaluateExpression(int left, int right, char operand)
        {
            var leftNode = Expression.Constant(left);
            var rightNode = Expression.Constant(right);
            switch(operand)
            {
                case '+':
                    var additionExpression = Expression.Add(leftNode, rightNode);
                    return Expression.Lambda<Func<int>>(additionExpression).Compile().ToString();
                case '-':
                    var subtractionExpression = Expression.Subtract(leftNode, rightNode);
                    return Expression.Lambda<Func<int>>(subtractionExpression).Compile().ToString();
                case '*':
                    var multiplyExpression = Expression.Multiply(leftNode, rightNode);
                    return Expression.Lambda<Func<int>>(multiplyExpression).Compile().ToString();
                case '/':
                    var divideExpression = Expression.Divide(leftNode, rightNode);
                    return Expression.Lambda<Func<int>>(divideExpression).Compile().ToString();
                default:
                    return "ERROR: Operand does not exist.";
            }
        }
        public IEnumerable<string> PostFixEvaluate(IEnumerable<string> postFixDataSet)
        {
            try
            {

            }
            finally
            {
                // Do nothing: this stops the iterator/yield
            }
        }
    }
}
