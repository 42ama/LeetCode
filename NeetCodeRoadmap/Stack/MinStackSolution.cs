using System;
using System.Collections.Generic;
using System.Linq;
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
    internal class MinStack
    {
        private int?[] _stack = new int?[20000];
        private int _pointer = 0;

        private int _minValue = int.MaxValue;

        private Dictionary<int, int> _minDictionary = new Dictionary<int, int>();


        public void Push(int val)
        {
            _pointer++;
            _stack[_pointer] = val;

            if (val < _minValue)
            {
                _minDictionary.Remove(_minValue);
                _minValue = val;
                _minDictionary[_minValue] = _pointer;
            }
        }

        // destructive
        public void Pop()
        {
            var currentValue = _stack[_pointer];
            _stack[_pointer] = null;
            _pointer--;

            if (_minDictionary.ContainsKey(currentValue.Value))
            {
                _minDictionary.Remove(currentValue.Value);
            }
        }

        // non-destructive
        public int Top()
        {
            return _stack[_pointer].Value;
        }

        // non-destructive
        public int GetMin()
        {
            if (_minDictionary.Count > 0)
            {
                return _minDictionary.First().Key;
            }
            else
            {
                return _stack.Min(i => i.HasValue
                                        ? i.Value
                                        : int.MaxValue);
            }
        }
    }
}
