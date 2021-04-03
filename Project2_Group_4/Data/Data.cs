using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4
{
    class Data
    {
        int Sno;
        string Equation;
        string Prefix { get; set; } 
        string Postfix { get; set; }
        string PrefixResult { get; set; }
        string PostfixResult { get; set; }
        public Data(int s, string eq)
        {
            Sno = s;
            Equation = eq;
        }
    }
}
