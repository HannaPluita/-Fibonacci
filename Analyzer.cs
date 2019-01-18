using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci.Logic;
using Fibonacci.UI;

namespace Fibonacci
{
    public class Analyzer: IDisposable, IAnalizeViewable
    {
        public const string LOWER_ABOVE_UPPER = "The lower limit cannot be higher than the last.";
        public const string UPPER_ZERO = "The upper limit cannot be zero.";

        public uint LowerLimit { get; set; }
        public uint UpperLimit { get; set; }

        protected uint _count = 0;

        public Analyzer()
        {
        }

        public Analyzer(uint lower, uint upper)
        {
            LowerLimit = lower;
            UpperLimit = upper;
        }

        public Analyzer(Analyzer an)
            :this(an.LowerLimit, an.UpperLimit)
        {
        }

        protected FibonacciList _list = new FibonacciList();

        public bool SetList()
        {
            return SetList(LowerLimit, UpperLimit);
        }

        public bool SetList(uint lower, uint upper)
        {
            if (lower > upper)
            {
                Output.OutputMessage(LOWER_ABOVE_UPPER);
                return false;
            }

            if(upper == 0)
            {
                Output.OutputMessage(UPPER_ZERO);
                return false;
            }

            FibonacciList _bufList = new FibonacciList();

            LowerLimit = lower;
            UpperLimit = upper;

            try
            {
                for (uint i = 0; ; ++i)
                {
                    _list.Add();

                    if(_list.PeekLast() >= lower && _list.PeekLast() <= upper)
                    {
                        _bufList.Add(_list.PeekLast());
                    }
                    
                    if(_list.PeekLast() > upper)
                    {
                        break;
                    }
                }

                _list = _bufList;

                _count = _bufList.Count;

                return true; ;
            }
            catch (StackOverflowListException e)
            {
                throw new StackOverflowListException(e.ToString());
            }
            catch (OutOfMemoryListException e)
            {
                throw new OutOfMemoryListException(e.ToString());
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException(String.Concat(Output.CANNOT_GET, Output.EMPTY_LIST), e);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public IViewable View
        {
            get
            {
                return (IViewable)_list;
            }
        }

        public uint Count
        {
            get
            {
                return _count;
            }
        }

        public void Dispose()
        {
            _list.Dispose();
        }

    }
}
