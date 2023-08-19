using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    /// <summary>
    /// https://leetcode.com/problems/top-k-frequent-elements/
    /// </summary>
    [Obsolete("Слабое решение, см BetterSolution")]
    internal class TopKFrequentSolution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            // Freq and number
            var dict = new SortedDictionary<int, int>();
            foreach (int number in nums)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number]++;
                }
                else
                {
                    dict.Add(number, 1);
                }
            }

            return dict.OrderByDescending(x => x.Value).Take(k).Select(i => i.Key).ToArray();
        }
    }
}
