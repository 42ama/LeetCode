using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    /**
     * Your MinStack object will be instantiated and called as such:
     * MinStack obj = new MinStack();
     * obj.Push(val);
     * obj.Pop();
     * int param_3 = obj.Top();
     * int param_4 = obj.GetMin();
     */
    internal class MinStackNeetCodeSolution
    {
        private int?[] _stack = new int?[20000];
        private int?[] _minStack = new int?[20000];

        private int _pointer = 0;

        private int _minValue = int.MaxValue;



        public void Push(int val)
        {
            var lastMinValue = _minStack[_pointer] ?? int.MaxValue;
            _pointer++;
            _stack[_pointer] = val;

            if (val < lastMinValue)
            {
                _minStack[_pointer] = val;
            }
            else
            {
                _minStack[_pointer] = lastMinValue;
            }
        }

        // destructive
        public void Pop()
        {
            var currentValue = _stack[_pointer];
            _minStack[_pointer] = null;
            _stack[_pointer] = null;
            _pointer--;
        }

        // non-destructive
        public int Top()
        {
            return _stack[_pointer].Value;
        }

        // non-destructive
        public int GetMin()
        {
            return _minStack[_pointer].Value;
        }

    }

}
