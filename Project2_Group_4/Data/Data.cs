/* Group:       4
 * Programmers: Anthony Merante, Colin Manliclic, Zina Long
 * Date:        April 6, 2021
 * 
 * Purpose: Data class to store and retrieve expression information
 */

namespace Project2_Group_4
{
    public class Data
    {
        // Data members
        public int Sno;
        public string Infix;
        public string Prefix { get; set; } 
        public string Postfix { get; set; }
        public string PrefixResult { get; set; }
        public string PostfixResult { get; set; }
        // Constructor
        public Data(int s, string eq)
        {
            Sno = s;
            Infix = eq;
            Prefix = "";
            Postfix = "";
            PrefixResult = "";
            PostfixResult = "";
        }
        // to string override
        public override string ToString()
        {
            return $"{Sno}: {Infix}";
        }
    }
}
