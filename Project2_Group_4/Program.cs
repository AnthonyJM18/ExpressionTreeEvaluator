using Project2_Group_4.Conversions;
using Project2_Group_4.FileClasses;
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
            foreach(string result in post.Convert())
            {
                dataset[count].Postfix = result;
                Console.WriteLine(count + ":\t" + dataset[count].Postfix);
                count++;
            }
            // Convert to prefix and store it in the data
            PrefixConversion pre = new PrefixConversion(dataset);
            count = 0;
            Console.WriteLine("Sno \tPostfix");
            foreach (string result in pre.Convert())
            {
                dataset[count].Prefix = result;
                Console.WriteLine(count + ":\t" + dataset[count].Prefix);
                count++;
            }
            // Calculate postfix result and store it in the data
            // Calculate prefix result and store it in the data

            // Display prefix results 

            // Display postfix results

            // Display all results

            // Prompt user if they want to view the results in XML format

        }
    }
}
