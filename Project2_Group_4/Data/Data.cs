using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4
{
    public class Data
    {
        public int Sno;
        public string Infix;
        public string Prefix { get; set; } 
        public string Postfix { get; set; }
        public string PrefixResult { get; set; }
        public string PostfixResult { get; set; }
        public Data(int s, string eq)
        {
            Sno = s;
            Infix = eq;
            Prefix = "";
            Postfix = "";
            PrefixResult = "";
            PostfixResult = "";
        }
        public override string ToString()
        {
            return $"{Sno}: {Infix}";
        }
    }
}
