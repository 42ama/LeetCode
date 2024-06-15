using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing.Round2
{
    internal class DuplicateIntegerSolution
    {
        public bool hasDuplicate_1(int[] nums)
        {
            var set = new HashSet<int>(nums);

            return set.Count != nums.Length;
        }

        public bool hasDuplicate_2(int[] nums)
        {
            var meet = new HashSet<int>();  
            for (int i = 0; i < nums.Length; i++)
            {
                if (meet.Contains(nums[i]))
                {
                    return true;
                }

                meet.Add(nums[i]);
            }

            return false;
        }
    }
}
