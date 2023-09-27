using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers
{
    [Obsolete]
    internal class _3SumSolution
    {
        private Dictionary<string, IList<int>> _matches = new Dictionary<string, IList<int>>();
        private int[] _nums;

        // Хуйня, по скорости не проходит. Сортируем и решаем two sum Относительно first
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) { return new List<IList<int>>(); }

            _nums = nums;

            // вернуть все тройки которые суммируются в ноль (нельзя использовать один элемент больше одного раза)            


            for (int firstPointer = 0; firstPointer <= nums.Length - 3; firstPointer++)
            {
                var secondPointer = firstPointer + 1;
                var thirdPointer = secondPointer + 1;

                while (true)
                {
                    CheckAndAdd(firstPointer, secondPointer, thirdPointer);
                    if (secondPointer + 1 == thirdPointer)
                    {
                        if (thirdPointer == nums.Length - 1) { break; }

                        thirdPointer++;
                        secondPointer = firstPointer + 1;
                    }
                    else
                    {
                        secondPointer++;
                    }
                }
            }

            return _matches.Select(i => i.Value).ToList();
        }

        private void CheckAndAdd(int firstPointer, int secondPointer, int thirdPointer)
        {
            var first = _nums[firstPointer];
            var second = _nums[secondPointer];
            var third = _nums[thirdPointer];

            var shouldAdd = (_nums[firstPointer] + _nums[secondPointer] + _nums[thirdPointer]) == 0;
            if (!shouldAdd)
            {
                return;
            }

            int max, mid, min;
            if (first > second)
            {
                if (first > third)
                {
                    max = first;
                    if (second > third)
                    {
                        mid = second;
                        min = third;
                    }
                    else
                    {
                        mid = third;
                        min = second;
                    }
                }
                else
                {
                    max = third;
                    mid = first;
                    min = second;
                }
            }
            else
            {
                if (first > third)
                {
                    max = second;
                    mid = first;
                    min = third;
                }
                else
                {
                    if (second > third)
                    {
                        max = second;
                        mid = third;
                    }
                    else
                    {
                        max = third;
                        mid = second;
                    }
                    min = first;
                }
            }

            _matches.TryAdd($"{max}{mid}{min}", new List<int> { first, second, third });
        }
    }
}
