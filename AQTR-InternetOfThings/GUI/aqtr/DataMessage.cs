using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aqtr
{
    class DataMessage
    {
        public string Identifier { get; }

        private int valueInt;
        public int ValueInt { get { return valueInt; } }

        private int valueIntOffset;
        public int ValueIntOffset
        {
            get { return valueIntOffset; }
            set
            {
                valueInt -= valueIntOffset;
                valueIntOffset = value;
                valueInt += valueIntOffset;
            } 
        }

        private double valueDouble;
        public double ValueDouble { get {return valueDouble; } }

        private double valueDoubleOffset;

        public double ValueDoubleOffset
        {
            get { return valueDoubleOffset; }
            set
            {
                valueDouble -= valueDoubleOffset;
                valueDoubleOffset = value;
                valueDouble += valueDoubleOffset;
            }
        }

        private bool valueBool;
        public bool ValueBool { get; }
       // public bool IsInvertedLogic { get; set; }

        /// <summary>
        /// Separates the input string into its string and data values. '=' or '|' should be separators, but contain only one of them
        /// Parameter may contain whitespaces
        /// Example usage var m = Message("Cars = 5") = > m.Identifier=="Cars"; m.ValueInt==5 
        /// </summary>
        /// <param name="message">The string to be converted to message format</param>
        public DataMessage(string message)
        {
            string[] tempArray;
            if (message.Contains('='))
            {
                tempArray = message.Split('=');
            }
            else
            {
                if (message.Contains('|'))
                {
                    tempArray = message.Split('|');
                }
                else
                {
                    throw new Exception("Invalid format: The string does not contain '=' or '|'");
                }
            }

            Identifier = tempArray[0];
            while (Identifier!="" && Identifier[Identifier.Length - 1] == ' ')
            {
                Identifier = Identifier.Substring(0, Identifier.Length - 1);
            }

            while (Identifier != "" && Identifier[0] == ' ')
            {
                Identifier = Identifier.Substring(1);
            }

            int i;
            if (Int32.TryParse(tempArray[1], out i))
            {
                valueInt = i;
            }
            else
            {
                valueInt = 0;
            }

            double d;
            if (Double.TryParse(tempArray[1], out d))
            {
                valueDouble = d;
            }
            else
            {
                valueDouble = 0;
            }

            bool b;
            if (Boolean.TryParse(tempArray[1], out b))
            {
                valueBool = b;
            }
            else
            {
                valueBool = false;
            }

            ValueDoubleOffset = 0;
            ValueIntOffset = 0;
            //IsInvertedLogic = false;
        }

    }
}
