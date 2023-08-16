using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
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
