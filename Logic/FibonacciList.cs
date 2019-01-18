using Fibonacci.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci.Logic
{
    public class FibonacciList: IViewable, IDisposable
    {
        protected const uint  FIRST = 0;
        protected const uint SECOND = 1;

        private Node _first = null;
        private Node _last = null;

        public void Add()
        {
            Node node = new Node();

            if (node == null)
            {
                throw new OutOfMemoryListException();
            }

            if (_first == null)
            {
                node.Info = FIRST;
                _first = node;
                _last = node;
                return;
            }

            if(_first.Next == null)
            {
                node.Info = SECOND;
                _first.Next = node;
                _last = node;
                _last.Prev = _first;
                return;
            }
            
            Node i = _first;
            for (; i.Next.Next != null; i = i.Next)
            {
            }
            node.Info = i.Info + i.Next.Info;
            i.Next.Next = node;
            node.Prev = i.Next;
            _last = node;
        }

        public void Add(uint info)
        {
            Node newElem = new Node(info);

            if (newElem == null)
            {
                throw new OutOfMemoryListException();
            }

            if (_first == null)
            {
                _first = newElem;
                _last = newElem;
            }
            else
            {
                Node i = _first;
                for (; i.Next != null; i = i.Next)
                {
                }
                i.Next = newElem;
                newElem.Prev = i;
                _last = newElem;
            }
        }

        public uint PeekLast()
        {
           
                uint result = 0;
                if (_last != null)
                {
                    result = _last.Info;
                }
                return result;
          
        }

        protected uint PeekFirst()
        {
            try
            {
                uint retVal = 0;
                if (_first.Next == null)
                {
                    retVal = _first.Info;
                    //_first = null; //GetFirst
                    //_last = null;
                }
                else
                {
                    retVal = _first.Info;
                    //_first = _first.Next;
                    //_first.Prev = null;
                }
                return retVal;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException(String.Concat(Output.CANNOT_GET, Output.EMPTY_LIST), e);
            }

        }

        public uint this[uint pos]                                   
        {
            get
            {
                try
                {
                    uint result = 0;

                    if (pos == 0)
                    {
                        result = PeekFirst();
                    }
                    else
                    {
                        Node current = _first;

                        for (int i = 0; i < pos - 1; ++i)
                        {
                            current = current.Next;
                        }

                        if (current.Next.Next == null)
                        {
                            result = PeekLast();
                        }
                        else
                        {
                            result = current.Next.Info;
                        }
                    }

                    return result;
                }
                catch (NullReferenceException e)
                {
                    if (_first == null)
                    {
                        throw new NullReferenceException(string.Format("{0}[{1}] {2}", Output.CANNOT_GET, pos, Output.EMPTY_LIST), e);
                    }

                    e.Data.Add("Position", pos);
                    e.Data.Add("MinIndex", 0);
                    e.Data.Add("MaxIndex", Count - 1);

                    throw new NullReferenceException(string.Format("{0}{1}", Output.INDEX_VALUE, Output.OUT_OF), e);
                }
            }
        }

        public uint Count
        {
            get
            {
                uint result = 0;

                for (Node i = _first; i != null; i = i.Next)
                {
                    ++result;
                }

                return result;
            }
        }
        
        public void Dispose()
        {
            _last = null;
            _first = null;

            GC.Collect();
        }

    }
}
