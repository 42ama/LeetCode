using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap._utils
{
    internal static class FrequencyMap
    {
        public static Dictionary<T, int> Make<T>(IEnumerable<T> collection) where T : notnull
        {
            var freqMap = new Dictionary<T, int>();
            foreach (var element in collection)
            {
                if (freqMap.ContainsKey(element))
                {
                    freqMap[element]++;
                }
                else
                {
                    freqMap.Add(element, 1);
                }
            }

            return freqMap;
        }
    }
}
