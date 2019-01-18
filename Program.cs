using Fibonacci.Logic;
using Fibonacci.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Output.OutputInstructions();

            if(Environment.GetCommandLineArgs().Length <= 1)
            {
                Application.RunConsoleInput();
            }
            else
            {
                Application.RunCommandArgs();
            }
        }
    }
}
