using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4.Conversions
{
    public class PrefixConversion
    {
        private List<Data> Dataset;

        public PrefixConversion(List<Data> d)
        {
            Dataset = d;
        }

        public IEnumerable<string> Convert()
        {
            try
            {

                StringBuilder equation = new StringBuilder();
                Stack<char> command;
                foreach (Data d in Dataset)
                {
                    command = new Stack<char>();
                    equation.Clear();
                    string expression = new string(d.Infix.Reverse().ToArray());
                    foreach (char c in expression)
                    {
                        if (char.IsDigit(c))
                        {
                            equation.Append(c);
                        }
                        else
                        {
                            if (c == ')')
                            {
                                command.Push(c);
                            }
                            else if (c == '(')
                            {
                                while (command.Peek() != ')')
                                {
                                    equation.Append(command.Pop());
                                }
                                command.Pop();
                            }
                            else
                            {
                                while (command.Count > 0 && GetPrecedence(command.Peek()) > GetPrecedence(c))
                                {
                                    equation.Append(command.Pop());
                                }
                                command.Push(c);
                            }
                        }
                    }
                    while (command.Count > 0)
                    {
                        equation.Append(command.Pop());
                    }
                    expression = new string(equation.ToString().Reverse().ToArray());
                    yield return expression;
                }
            }
            finally
            {

            }
        }
        private int GetPrecedence(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 1;

                case '*':
                case '/':
                    return 2;

                case '^':
                    return 3;
            }
            return -1;
        }
    }
}
