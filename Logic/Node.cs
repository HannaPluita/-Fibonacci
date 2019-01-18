using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Logic
{
    public class Node
    {
        public Node()
        {
            Prev = null;
            Next = null;
        }

        public Node(uint info)
        {
            Info = info;
            Prev = null;
            Next = null;
        }

        public Node(Node n)
            :this(n.Info)
        { }

        public uint Info { get; set; }
        public Node Prev { get; set; }
        public Node Next { get; set; }
    }
}
