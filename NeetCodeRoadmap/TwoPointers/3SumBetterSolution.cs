using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers
{
    internal class _3SumBetterSolution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            if (nums.Length < 3) { return new List<IList<int>>(); }

            Array.Sort(nums);

            var result = new List<IList<int>>();

            for (int firstPointer = 0; firstPointer <= nums.Length - 3; firstPointer++)
            {
                var first = nums[firstPointer];
                if (firstPointer > 0
                    && first == nums[firstPointer - 1])
                {
                    // Пропускаем одинаковые числа, для них уже рассчитали
                    continue;
                }

                if (first > 0)
                {
                    // Если первое число больше 0, то все остальные точно больше и нет смысла считать.
                    break;
                }

                for (int secondPointer = firstPointer + 1; secondPointer < nums.Length; secondPointer++)
                {
                    var second = nums[secondPointer];
                    if (secondPointer > firstPointer + 1
                        && second == nums[secondPointer - 1])
                    {
                        // Пропускаем одинаковые числа, для них уже рассчитали
                        continue;
                    }

                    for (int thirdPointer = secondPointer + 1; thirdPointer < nums.Length; thirdPointer++)
                    {
                        var third = nums[thirdPointer];
                        if (thirdPointer > secondPointer + 1
                            && third == nums[thirdPointer - 1])
                        {
                            // Пропускаем одинаковые числа, для них уже рассчитали
                            continue;
                        }

                        if (secondPointer == thirdPointer) { continue; }

                        var shouldAdd = (first + second + third) == 0;
                        if (shouldAdd)
                        {
                            result.Add(new List<int> { first, second, third });
                        }
                    }
                }
            }

            return result;
        }
    }
}
