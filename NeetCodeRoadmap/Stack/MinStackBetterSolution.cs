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
    internal class MinStackBetterSolution
    {
        private int?[] _stack = new int?[20000];
        private int _pointer = 0;

        private int _minValue = int.MaxValue;

        private List<int?> _sortedValues = new List<int?>();


        public void Push(int val)
        {
            _pointer++;
            _stack[_pointer] = val;

            // Ниже магия поиска и вставки значения с сортировкой на ходу.
            var indexOfFoundItem = _sortedValues.BinarySearch(val);
            if (indexOfFoundItem < 0) { indexOfFoundItem = ~indexOfFoundItem; }
            _sortedValues.Insert(indexOfFoundItem, val);
        }

        // destructive
        public void Pop()
        {
            var currentValue = _stack[_pointer];
            _stack[_pointer] = null;
            _pointer--;

            _sortedValues.Remove(currentValue);
        }

        // non-destructive
        public int Top()
        {
            return _stack[_pointer].Value;
        }

        // non-destructive
        public int GetMin()
        {
            return _sortedValues[0].Value;
        }

    }

}
