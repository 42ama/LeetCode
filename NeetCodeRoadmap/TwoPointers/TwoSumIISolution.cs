using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers
{
    internal class TwoSumIISolution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var leftPointer = 0;
            var rightPointer = numbers.Length - 1;

            var leftNumber = numbers[leftPointer];
            var rightNumber = numbers[rightPointer];

            while (true)
            {
                if (leftNumber + rightNumber == target)
                {
                    return new int[] { leftPointer + 1, rightPointer + 1 };
                }

                while (leftNumber + rightNumber > target)
                {
                    rightPointer--;
                    rightNumber = numbers[rightPointer];
                }

                while (leftNumber + rightNumber < target)
                {
                    leftPointer++;
                    leftNumber = numbers[leftPointer];
                }
            }

            throw new Exception();
        }
    }
}
