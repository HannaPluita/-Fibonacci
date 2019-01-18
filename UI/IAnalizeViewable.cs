using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.UI
{
    public interface IAnalizeViewable
    {
        uint LowerLimit { get; set; }

        uint UpperLimit { get; set; }

        uint Count { get; }

        IViewable View { get; }
    }
}
