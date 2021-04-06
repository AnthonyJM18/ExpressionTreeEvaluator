using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4.Expressions
{
    public class CompareExpressions : IComparer<string>
    {
        public int Compare(string prefix, string postfix)
        {
            if (prefix == postfix)
                return 1;
            else
                return -1;
        }
    }
}
