/* Group:       4
 * Programmers: Anthony Merante, Colin Manliclic, Zina Long
 * Date:        April 6, 2021
 * 
 * Purpose: Driver program for reading in and displaying the program
 */
using Project2_Group_4.Conversions;
using Project2_Group_4.FileClasses;
using Project2_Group_4.Expressions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Project2_Group_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // File paths
            const string DATA_PATH = "./Data/Project 2_INFO_5101.csv";
            const string XML_PATH = "./Data/Project2_INFO_5101.xml";
            // Load data
            List<Data> dataset = CSVFile.CSVDeserialize(DATA_PATH);

            // Print infix equations
            Console.WriteLine("\nSno \tInfix");
            foreach (Data result in dataset)
            {
                Console.WriteLine(result.Sno + ":\t" + result.Infix);
            }
            // Convert to postfix and store it in the data and then print
            PostfixConversion post = new PostfixConversion(dataset);
            int count = 0;
            Console.WriteLine("\nSno \tPostfix");
            foreach (string result in post.Convert())
            {
                dataset[count].Postfix = result;
                Console.WriteLine(dataset[count].Sno + ":\t" + dataset[count].Postfix);
                count++;
            }
            // Convert to prefix and store it in the data and then print
            PrefixConversion pre = new PrefixConversion(dataset);
            count = 0;
            Console.WriteLine("\nSno \tPrefix");
            foreach (string result in pre.Convert())
            {
                dataset[count].Prefix = result;
                Console.WriteLine(dataset[count].Sno + ":\t" + dataset[count].Prefix);
                count++;
            }
            // Calculate postfix result and store it in the data and then print
            count = 0;
            Console.WriteLine("\nSno \tPostFix Results");
            foreach (string result in ExpressionEvaluation.PostFixEvaluate(post.Convert()))
            {
                dataset[count].PostfixResult = result;
                Console.WriteLine(count + ":\t" + result);
                count++;
            }

            // Calculate prefix result and store it in the data and then print
            count = 0;
            Console.WriteLine("\nSno \tPrefix Results");
            foreach (string result in ExpressionEvaluation.PrefixEvaluate(pre.Convert()))
            {
                dataset[count].PrefixResult = result;
                Console.WriteLine(count + ":\t" + result);
                count++;
            }

            // Display all results
            CompareExpressions ce = new CompareExpressions();
            Console.WriteLine($"\nSno\t{"Infix",-20} {"Prefix",-17} {"Postfix",-17} {"Prefix Result",-15} {"Postfix Result",-15} {"Match",-15}");
            foreach (Data d in dataset)
            {
                Console.WriteLine($"{d.Sno}\t{d.Infix,-20} {d.Prefix,-17} {d.Postfix,-17} {d.PrefixResult,-15} {d.PostfixResult,-15} {(ce.Compare(d.PrefixResult, d.PostfixResult) == 1 ? "True" : "False"),-15}");
            }

            // Prompt user if they want to view the results in XML format
            ConsoleKey response;
            // Validation
            do
            {
                Console.Write("\nWould you like to view the results in XML format? [Y/N]:");
                response = Console.ReadKey(false).Key;   // true is intercept key (dont show), false is show
                if (response != ConsoleKey.Enter)
                    Console.WriteLine();

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            // Generate XML if user selected yes, else don't
            if (response == ConsoleKey.Y)
            {
                Console.WriteLine("XML Generated!");
                // Uses XMLExtensions
                using (StreamWriter outputFile = new StreamWriter(XML_PATH))
                {
                    outputFile.WriteStartDocument();
                    outputFile.WriteStartRootElement();

                    foreach (Data d in dataset)
                    {
                        outputFile.WriteStartElement();
                        outputFile.WriteAttribute("sno", d.Sno.ToString());
                        outputFile.WriteAttribute("infix", d.Infix);
                        outputFile.WriteAttribute("prefix", d.Prefix);
                        outputFile.WriteAttribute("postfix", d.Postfix);
                        outputFile.WriteAttribute("evaluation", d.PostfixResult);
                        outputFile.WriteAttribute("comparison", (ce.Compare(d.PrefixResult, d.PostfixResult) == 1 ? "True" : "False"));
                        outputFile.WriteEndElement();
                    }

                    outputFile.WriteEndRootElement();
                }

                // Opens XML in Google Chrome browser
                Process.Start(@"cmd.exe ", @$"/c start chrome {XML_PATH}");
            } 
        }
    }
}
