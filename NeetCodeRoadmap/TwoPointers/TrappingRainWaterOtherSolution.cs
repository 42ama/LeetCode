using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers
{
    /// <summary>
    /// Два пойнтера
    /// </summary>
    internal class TrappingRainWaterOtherSolution
    {
        public int Trap(int[] height)
        {
            if (height.Length < 3) { return 0; }

            var leftPointer = 0;
            var rightPointer = 1;

            var result = 0;

            var shouldSetLeft = true;

            var left = 0;
            var right = 0;
            while (true)
            {
                if (leftPointer == height.Length || rightPointer == height.Length) { break; }

                if (shouldSetLeft)
                {
                    left = height[leftPointer];
                }
                
                right = height[rightPointer];

                if (right >= left)
                {
                    var min = left < right
                                ? left
                                : right;
                    leftPointer++;
                    while (leftPointer < rightPointer)
                    {
                        var current = height[leftPointer];
                        result += min - current;
                        leftPointer++;
                    }
                    rightPointer++;

                    shouldSetLeft = true;
                }
                else
                {
                    rightPointer++;
                }

                if (rightPointer == height.Length)
                {
                    if (left > right)
                    {
                        left -= 1;
                        rightPointer = leftPointer + 1;
                        shouldSetLeft = false;
                    }
                }
            }

            if (leftPointer == height.Length) { rightPointer--; }
            if (rightPointer == height.Length) { rightPointer--; }

            if (leftPointer != rightPointer)
            {
                var min = left < right
                            ? left
                            : right;
                leftPointer++;
                while (leftPointer < rightPointer)
                {
                    var current = height[leftPointer];
                    result += min - current;
                    leftPointer++;
                }
            }

            return result;
        }
    }
}
