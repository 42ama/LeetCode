using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    internal class TwoSumSolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            // Key = [target - Number] - искомое число, Value = [index]
            var dictionary = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var number = nums[i];
                // Если мы в искомом числе
                var isFound = dictionary.TryGetValue(number, out var correctNumberIndex);
                if (isFound)
                {
                    var result = new int[] { correctNumberIndex, i };
                    return result;
                }

                var targetMinusNumber = target - number;
                if (!dictionary.TryGetValue(targetMinusNumber, out var _))
                {
                    dictionary.Add(targetMinusNumber, i);
                }
            }

            return null;
        }
    }
}
