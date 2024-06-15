using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.BinarySearch
{
    internal class BinarySearchSolution
    {
        public int Search(int[] nums, int target)
        {
            var leftBorder = 0;
            var rightBorder = nums.Length - 1;
            while (true)
            {
                if (rightBorder - leftBorder <= 1)
                {
                    if (nums[rightBorder] == target)
                    {
                        return rightBorder;
                    }
                    else if (nums[leftBorder] == target)
                    {
                        return leftBorder;
                    }
                    else
                    {
                        return -1;
                    }
                }

                var candidateIndex = (rightBorder + leftBorder) / 2;
                var candidate = nums[candidateIndex];

                if (target == candidate)
                {
                    return candidateIndex;
                }
                else if (target > candidate)
                {
                    leftBorder = candidateIndex;
                }
                else
                {
                    rightBorder = candidateIndex;
                }
            }
        }
    }
}
