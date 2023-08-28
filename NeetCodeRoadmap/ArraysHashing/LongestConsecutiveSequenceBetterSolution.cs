using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    internal class LongestConsecutiveSequenceBetterSolution
    {
        // You must write an algorithm that runs in O(n) time.
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) { return 0; }

            var set = new HashSet<int>(nums);

            var longestSequence = 0;
            foreach (var number in set)
            {
                // Ищем начало секвенции
                if (!set.Contains(number - 1))
                {
                    var numberOnTest = number + 1;
                    var currentSequence = 1;
                    while (set.Contains(numberOnTest))
                    {
                        currentSequence++;
                        numberOnTest += 1;
                    }
                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                    }
                }
            }

            return longestSequence;
        }   
    }
}
