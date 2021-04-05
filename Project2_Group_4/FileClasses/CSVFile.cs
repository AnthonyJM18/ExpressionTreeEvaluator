using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4.FileClasses
{
    public static class CSVFile
    {
        public static List<Data> CSVDeserialize(string path)
        {
            // create a list to be returned
            List<Data> data = new List<Data>();

            List<string> lines = File.ReadAllLines(path).ToList();
            // Skip first line'
            lines.RemoveAt(0);
            // read csv data line by line
            foreach (string line in lines)
            {
                // split each line by the comma
                string[] split = line.Split(',');
                // something like Data d = new Data(split[0],split[1]);
                // add data to list
                data.Add(new Data(int.Parse(split[0]), split[1]));
            }

            // return list
            return data;
        }
    }
}
