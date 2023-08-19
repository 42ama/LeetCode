using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    /// <summary>
    /// https://leetcode.com/problems/contains-duplicate/
    /// </summary>
    internal class ContainsDuplicateSolution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var set = new HashSet<int>();
            foreach (var number in nums)
            {
                if (set.Contains(number)) {return true;}

                set.Add(number);
            }
            return false;
        }
    }
}
