using NeetCodeRoadmap._utils;
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
    internal class TopKFrequentBetterSolution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var freqMap = new Dictionary<int, int>();
            foreach (int number in nums)
            {
                if (freqMap.ContainsKey(number))
                {
                    freqMap[number]++;
                }
                else
                {
                    freqMap.Add(number, 1);
                }
            }

            var priorityQueue = new PriorityQueue<int, int>();
            foreach (var item in freqMap)
            {
                var priority = int.MaxValue - item.Value; // Самый меньший приоритет - самый большой.
                priorityQueue.Enqueue(item.Key, priority);
            }

            var result = new int[k];
            for (int i = 0; i < k; i++)
            {
                result[i] = priorityQueue.Dequeue();
            }

            return result;
        }
    }
}
