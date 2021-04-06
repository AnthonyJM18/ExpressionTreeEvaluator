﻿/* Group:       4
 * Programmers: Anthony Merante, Colin Manliclic, Zina Long
 * Date:        April 6, 2021
 * 
 * Purpose: Conversion method to convert infix to postfix notation
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4.Conversions
{
    public class PostfixConversion
    {
        // Data member
        private List<Data> Dataset;
        // Constructor
        public PostfixConversion(List<Data> d)
        {
            Dataset = d;
        }
        /// <summary>
        /// Converts all Data objects infix equation to postfix. 
        /// Uses yield to loop through the dataset
        /// </summary>
        /// <returns>An IEnumerable representing the most recent conversion</returns>
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
                    foreach (char c in d.Infix)
                    {
                        if (char.IsDigit(c))
                        {
                            equation.Append(c);
                        }
                        else
                        {
                            if (c == '(')
                            {
                                command.Push(c);
                            }
                            else if (c == ')')
                            {
                                while (command.Peek() != '(')
                                {
                                    equation.Append(command.Pop());
                                }
                                command.Pop();
                            }
                            else
                            {
                                while (command.Count > 0 && GetPrecedence(command.Peek()) >= GetPrecedence(c))
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
                    yield return equation.ToString();
                }
            } finally
            {
                // Do nothing: this stops the iterator/yield
            }
        }

        /// <summary>
        /// Gets operator precendce
        /// </summary>
        /// <param name="ch">the operator</param>
        /// <returns>An int representing the operators precendence</returns>
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
