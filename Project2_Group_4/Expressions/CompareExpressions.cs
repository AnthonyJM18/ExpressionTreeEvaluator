/* Group:       4
 * Programmers: Anthony Merante, Colin Manliclic, Zina Long
 * Date:        April 6, 2021
 * 
 * Purpose:     Compares a prefix and postfix string results
 */

using System.Collections.Generic;

namespace Project2_Group_4.Expressions
{
    public class CompareExpressions : IComparer<string>
    {
        /// <summary>
        /// implements IComparer compare method to compare a prefix and postfix evaluation
        /// </summary>
        /// <param name="prefixResult"></param>
        /// <param name="postfixResult"></param>
        /// <returns>Returns 1 if results equal, and -1 if not</returns>
        public int Compare(string prefixResult, string postfixResult)
        {
            if (prefixResult == postfixResult)
                return 1;
            else
                return -1;
        }
    }
}
