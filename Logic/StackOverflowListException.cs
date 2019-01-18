using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Logic
{
    class StackOverflowListException : Exception
    {
        public const string EXCEPTION_MESSAGE_1 = "StackOverflowListException: ";
        public const string EXCEPTION_MESSAGE_2 = "The list object contains too many nested method calls or too deep or unbounded recursion. ";
        public const string EXCEPTION_MESSAGE_3 = "The execution stack overflows.";

        public StackOverflowListException()
            : base(String.Concat(EXCEPTION_MESSAGE_1, EXCEPTION_MESSAGE_2))
        {
        }

        public StackOverflowListException(string message)
            : base(message)
        {
        }
        public StackOverflowListException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public override string ToString()
        {
            return string.Format("{0}{1}\n{2}", EXCEPTION_MESSAGE_1, EXCEPTION_MESSAGE_3, EXCEPTION_MESSAGE_2);
        }
    }
}
