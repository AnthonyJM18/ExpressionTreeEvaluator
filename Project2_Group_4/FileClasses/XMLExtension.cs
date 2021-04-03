using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Group_4.FileClasses
{
    // Supposed to be an extension method but idk what we are extending from
    public static class XMLExtension
    {
        public static void WriteStartDocument()
        {
            // This method should include xml version and encoding
        }

        public static void WriteStartRootElement()
        {
            //  This method should add the root tag to the file
        }

        public static void WriteEndRootElement()
        {
            // This method should end the root tag.
        }

        public static void WriteStartElement()
        {
            // This method should add the element tag to the file
        }

        public static void WriteEndAttribute()
        {
            //This method should end the element tag
        }

        public static void WriteAttribute()
        {
            // This method should add each attribute with its values
        }
    }
}
