using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.UI
{
    public static class Output
    {
        #region    Constants
        public const string INPUT_SEQUENCE = "Please, input two positive integer numbers in format: <Start_Value>,<Final_Value>";

        public const string INCORRECT_DATA = "The data you have entered is incorrect.";
        public const string CORRECT_DATA = "The data you have entered is in correct format.";
        public const string NOT_REAL = "Your have entered a string of not integer number format.";
        public const string ONE_STRING_EXPECTED = "One-string entry data with two positive integer numbers expected.";
        public const string TRY_AGAIN_WITH_RESTART = "Please, restart the application with entry data as parameter.";
        public const string APP_CANNOT_PROCESS = "The application cannot process data in a similar format";
        public const string COMPLETED = "Application completed.";

        public const string FORMAT_REQUIREMENTS = "Expected a positive number of integer numeric format.";
        public const string MAX = "Maximum allowable value is ";

        public const string EXTRA = " Extra details:";
        public const string KEY = "   Key:";
        public const string DATA = "  Data:";
        public const string TRACE = "  StackTrace:";
        public const string SITE = "  TargetSite:";

        public const string CANNOT_GET = "You cannot get the element of the list";
        public const string EMPTY_LIST = " because the list is empty.";
        public const string INDEX_VALUE = "The value of index ";
        public const string OUT_OF = "is out valid range.";

        public const string MIDDLE_LINE = "--------------------------------------------";
        public const string FINISH_LINE = "============================================";
        public const string RANGE = "============= Fibonacci range: =============";
        public const string START = " Start value:";
        public const string FINAL = " Final value:";
        public const string LENGTH = "Total length:";

        public const uint VIEW_CELL_NUMBER = 15;
        public const uint MAX_VALUE = uint.MaxValue;

        #endregion

        public static void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OutputMessageSet(params string[] strings)
        {
            StringBuilder sb = new StringBuilder();

            foreach(string s in strings)
            {
                sb.Append(s);
            }

            Console.WriteLine(sb.ToString());
        }

        public static void OutputFiboToConsole(IAnalizeViewable view)
        {
            Console.WriteLine(RANGE);
            Console.WriteLine(string.Format("{0}{1}", START, view.LowerLimit));
            Console.WriteLine(string.Format("{0}{1}", FINAL, view.UpperLimit));
            Console.WriteLine(string.Format("{0}{1}", LENGTH, view.Count));
            Console.WriteLine(MIDDLE_LINE);

            for (uint i = 0; i < view.Count; ++i)
            {
                Console.Write("{0}  ", view.View[i]);
                
                if (i == VIEW_CELL_NUMBER)
                {
                    i = 0;
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
            Console.WriteLine(FINISH_LINE);
        }

        public static void OutputInstructions()
        {
            string path = @"..\..\Resources\Info.txt";

            try
            {
                if (File.Exists(path))
                {
                    string[] info = File.ReadAllLines(path);

                    foreach (string str in info)
                    {
                        Console.WriteLine(str);
                    }
                }
            }
            catch(Exception e)
            {
                e.Data.Add("File Path:", path);
                e.Data.Add("File Operation:", "Try to read all lines.");

                Console.WriteLine(e.Message);
                foreach(DictionaryEntry entry in e.Data)
                {
                    Console.WriteLine(string.Format("{0} {1}", entry.Key, entry.Value));
                }
            }
            
        }

        public static void CorrectFormatInfo()
        {
            Console.WriteLine(FORMAT_REQUIREMENTS);
            Console.WriteLine(String.Concat(MAX, MAX_VALUE));
        }

        public static void OutputExceptionInfo(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine("{0} {1}", SITE, e.StackTrace);
            Console.WriteLine("{0} {1}", TRACE, e.TargetSite.ToString());
            
            if (e.Data.Count > 0)
            {
                Console.WriteLine(EXTRA);

                foreach (DictionaryEntry entry in e.Data)
                {
                    Console.WriteLine(" {0} {1}        {2} {3}",KEY, entry.Key.ToString(), DATA, entry.Value);
                }
            }
        }
    }

}
