using Fibonacci.Logic;
using Fibonacci.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public static class Application
    {
        public const byte PARAMETERS_COUNT = 2;
        public const string NULL_ENTRY_PARAMETERS = "The application cannot process data if null entry parameters.";
        public const string SMALL_NUMBER_PARAM = "Small number of entry parameters. Not enough for the application to work.";
        public const string EMPTY_ARG = "The empty argument.";
        public const string INVALID_ARG = "The argument of invalid format.";
        public const string INCORRECT_ARGS = "The command arguments are of incorrect format.";
        public const string ARG_ACCEPTED = "The command argument is accepted by application.";

        public static void RunConsoleInput()
        {
            uint lower;
            uint upper;

            Input.ConsoleInputValueAttempts(out lower);
            Input.ConsoleInputValueAttempts(out upper);

            Analize(lower, upper);
        }

        public static void RunCommandArgs()
        {
            string[] appArgs;

            if (!GetCommandArgs(out appArgs))
            {
                return;
            }

            uint lower;
            uint upper;

            if(ParseArg(appArgs[0], out lower) && ParseArg(appArgs[1], out upper))
            {
                Analize(lower, upper);
            }
            else
            {
                Output.OutputMessage(INCORRECT_ARGS);
                Output.OutputMessage(Output.COMPLETED);
            }
        }

        public static bool GetCommandArgs(out string[] args)
        {
            string[] arguments = Environment.GetCommandLineArgs();

            if (arguments == null)
            {
                Output.OutputMessage(NULL_ENTRY_PARAMETERS);
                Output.OutputMessage(Output.COMPLETED);

                args = null;
                return false;
            }

            if (arguments.Length < PARAMETERS_COUNT + 1)
            {
                Output.OutputMessage(SMALL_NUMBER_PARAM);

                args = null;
                return false;
            }

            string[] appArgs = new string[PARAMETERS_COUNT];

            for (int i = 1; i <= PARAMETERS_COUNT; ++i)
            {
                if (!string.IsNullOrEmpty(arguments[i]) && !string.IsNullOrWhiteSpace(arguments[i]))
                {
                    appArgs[i - 1] = arguments[i].Trim(Input.TRIM_CHARS);
                }
            }

            args = appArgs;

            return true;
        }

        public static void Analize(uint lower, uint upper)
        {
            Analyzer analyzer = new Analyzer(lower, upper);

            try
            {
                if (analyzer.SetList())
                {
                    Output.OutputFiboToConsole(analyzer as IAnalizeViewable);
                }
            }
            catch (StackOverflowListException e)
            {
                Output.OutputExceptionInfo(e);
            }
            catch (OutOfMemoryListException e)
            {
                Output.OutputExceptionInfo(e); ;
            }
            catch (NullReferenceException e)
            {
                Output.OutputExceptionInfo(e); ;
            }
            catch (Exception e)
            {
                Output.OutputExceptionInfo(e);
            }
            finally
            {
                Output.OutputMessage(Output.COMPLETED);
                analyzer.Dispose();
            }

            Console.ReadLine();
        }

        public static bool ParseArg(string arg, out uint result)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                Output.OutputMessage(EMPTY_ARG);

                result = 0;
                return false;
            }

            if (!uint.TryParse(arg, out result))
            {
                Output.OutputMessage(INVALID_ARG);

                result = 0;
                return false;
            }
            else
            {
                Output.OutputMessage(ARG_ACCEPTED);
            }

            return true;
        }
    }
}
