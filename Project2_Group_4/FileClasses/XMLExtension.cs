/* Group:       4
 * Programmers: Anthony Merante, Colin Manliclic, Zina Long
 * Date:        April 6, 2021
 * Purpose:     XML Extension that extends StreamWriter to interact with the Program to write an XML file of the results.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4.FileClasses
{
    // Supposed to be an extension method but idk what we are extending from
    public static class XMLExtension
    {
        public static void WriteStartDocument(this StreamWriter stream)
        {
            // This method should include xml version and encoding
            stream.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        }

        public static void WriteStartRootElement(this StreamWriter stream)
        {
            //  This method should add the root tag to the file
            stream.WriteLine("<root>");
        }

        public static void WriteEndRootElement(this StreamWriter stream)
        {
            // This method should end the root tag.
            stream.WriteLine("</root>");
        }

        public static void WriteStartElement(this StreamWriter stream)
        {
            // This method should add the element tag to the file
            stream.WriteLine("\t<element>");
        }

        public static void WriteEndElement(this StreamWriter stream)
        {
            //This method should end the element tag
            stream.WriteLine("\t</element>");
        }

        public static void WriteAttribute(this StreamWriter stream, string key, string value)
        {
            // This method should add each attribute with its values
            stream.WriteLine($"\t\t<{key}>{value}</{key}>");
        }
    }
}
