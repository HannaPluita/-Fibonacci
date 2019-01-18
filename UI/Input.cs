using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.UI
{
    static public class Input
    {
        public const string EMPTY = "You have entered an empty string.";
        public const string FORMAT = "The string that is expected in positive integer number format with one value.";
        public const string INCORRECT = "Data is incorrect.";
        public const string ENTERED_LOWER = "You heve entered the lower limit: ";
        public const string LOWER = "Please, enter the lower limit of the range.";
        public const string UPPER = "Please, enter the upper limit of the range.";
        public const string CONTINUE = "Do you want to continue?      Y|y  -  YES,   other  - NO";
        public const string LOWER_AGAIN = "Please, try again to enter the lower limit of the range.";
        public const string UPPER_AGAIN = "Please, try again to enter the upper limit of the range.";

        public static readonly char[] TRIM_CHARS = new char[]{ ' ', '\t', ',' };

        public static bool ConsoleInputParameter(out uint result, string inviteMessage)
        {
            if (inviteMessage != "")
            {
                Console.WriteLine(inviteMessage);
            }

            result = 0;

            string enter = "";

            Console.WriteLine(FORMAT);

            bool assigned = false;

            enter = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(enter))
            {
                Console.WriteLine(EMPTY);
            }

            assigned = uint.TryParse(enter, out result);

            if (!assigned)
            {
                Console.WriteLine(INCORRECT); ;
            }

            return assigned;
        }

        public static bool ConsoleInputValueAttempts(out uint data)
        {
            if (ConsoleInputParameter(out data, LOWER))
            {
                Output.OutputMessageSet(ENTERED_LOWER, data.ToString());
                return true;
            }

            bool hasResult = false;

            if (Input.Continue())
            {
                hasResult = ConsoleInputParameter(out data, LOWER);

                if (hasResult)
                {
                    Output.OutputMessageSet(ENTERED_LOWER, data.ToString());
                }
                else
                {
                    Output.OutputMessage(Output.COMPLETED);
                }
            }
            else
            {
                Output.OutputMessage(Output.COMPLETED);
            }

            return hasResult;
        }

        public static bool Continue()
        {
            Console.WriteLine(CONTINUE);

            bool contin = false;

            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input))
            {
                return contin;
            }

            input = input.Trim(TRIM_CHARS);

            if(input.ToLower() == "y" || input.ToLower() == "yes")
            {
                contin = true;
            }

            return contin;
        }

        }
}
