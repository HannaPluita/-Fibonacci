using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.UI
{
    public interface IViewable
    {
        uint this[uint index] { get; }

        uint Count { get; }
    }
}
