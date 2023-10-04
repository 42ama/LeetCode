using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers
{
    internal class ContainerWithMostWaterSolution
    {
        public int MaxArea(int[] height)
        {
            if (height.Length < 2) {return 0; }


            var leftPointer = 0;

            var rightPointer = height.Length - 1;
            var maxArea = CalculateAreaForLeftRight(height, leftPointer, rightPointer, 0);

            while (true)
            {
                if (leftPointer >= rightPointer || rightPointer <= leftPointer) { break; }

                var left = height[leftPointer];
                var right = height[rightPointer];

                if (left < right)
                {
                    leftPointer++;
                }
                else
                {
                    rightPointer--;
                }

                maxArea = CalculateAreaForLeftRight(height, leftPointer, rightPointer, maxArea);
            }

            return maxArea;
        }

        /// <summary>
        /// Можно вынести в основной цикл, переиспользовать переменные и не придётся min считать - будет оптимальнее.
        /// </summary>
        private int CalculateAreaForLeftRight(int[] height, int leftPointer, int rightPointer, int maxArea)
        {
            var left = height[leftPointer];
            var right = height[rightPointer];

            if (left == 0 || right == 0) { return maxArea; }

            var dist = rightPointer - leftPointer; // Мб +- 1

            var min = left < right ? left : right;

            var currentArea = min * dist;
            var result = currentArea > maxArea
                        ? currentArea
                        : maxArea;
            return result;
        }
    }
}
