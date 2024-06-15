using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing.Round2
{
    internal class TwoSumSolution
    {
        // O(N^2)
        public int[] TwoSum_1(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j) { continue; }
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }

            throw new InvalidDataException("Must be strictly one answer");
        }

        public int[] TwoSum_2(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>(nums.Length); // value - index
            for (int i = 0; i < nums.Length;i++)
            {
                var potential = target - nums[i];
                if (dict.ContainsKey(potential))
                {
                    return new int[2] { i, dict[potential] };
                }

                dict.TryAdd(nums[i], i);
            }

            throw new InvalidDataException("Must be strictly one answer");
        }
    }
}
