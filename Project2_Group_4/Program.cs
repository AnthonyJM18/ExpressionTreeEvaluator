using Project2_Group_4.Conversions;
using Project2_Group_4.FileClasses;
using Project2_Group_4.Expressions;
using System;
using System.Collections.Generic;

namespace Project2_Group_4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string DATA_PATH = "./Data/Project 2_INFO_5101.csv";
            // Load data
            List<Data> dataset = CSVFile.CSVDeserialize(DATA_PATH);

            // Convert to postfix and store it in the data
            PostfixConversion post = new PostfixConversion(dataset);
            int count = 0;
            Console.WriteLine("Sno \tPostfix");
            foreach (string result in post.Convert())
            {
                dataset[count].Postfix = result;
                Console.WriteLine(dataset[count].Sno + ":\t" + dataset[count].Postfix);
                count++;
            }
            //Postfix evaluation
            count = 0;
            Console.WriteLine("Sno \tPostfixEVAL");
            foreach (string result in ExpressionEvaluation.PostFixEvaluate(post.Convert()))
            {
                dataset[count].PostfixResult = result;
                Console.WriteLine(dataset[count].Sno + ":\t" + result);
                count++;
            }

            // Convert to prefix and store it in the data
            PrefixConversion pre = new PrefixConversion(dataset);
            count = 0;
            Console.WriteLine("Sno \tPostfix");
            foreach (string result in pre.Convert())
            {
                dataset[count].Prefix = result;
                Console.WriteLine(dataset[count].Sno + ":\t" + dataset[count].Prefix);
                count++;
            }
            // Calculate postfix result and store it in the data
            count = 0;
            Console.WriteLine("Sno \tPostFix Res");
            foreach (string result in ExpressionEvaluation.PostFixEvaluate(post.Convert()))
            {
                dataset[count].PostfixResult = result;
                Console.WriteLine(count + ":\t" + result);
                count++;
            }

            // Calculate prefix result and store it in the data
            count = 0;
            Console.WriteLine("Sno \tPrefix Res");
            foreach (string result in ExpressionEvaluation.PreFixEvaluate(pre.Convert()))
            {
                dataset[count].PrefixResult = result;
                Console.WriteLine(count + ":\t" + result);
                count++;
            }

            // Display prefix results 

            // Display postfix results

            // Display all results
            CompareExpressions ce = new CompareExpressions();
            Console.WriteLine($"Sno\t{"Infix",-20} {"Prefix",-17} {"Postfix",-17} {"Prefix Result",-15} {"Postfix Result",-15} {"Match",-15}");
            foreach (Data d in dataset)
            {
                Console.WriteLine($"{d.Sno}\t{d.Infix,-20} {d.Prefix,-17} {d.Postfix,-17} {d.PrefixResult,-15} {d.PostfixResult,-15} {(ce.Compare(d.PrefixResult, d.PostfixResult) == 1 ? "True" : "False"),-15}");
            }

            // Prompt user if they want to view the results in XML format

        }
    }
}
