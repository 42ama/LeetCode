using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.BinarySearch
{
    internal class TimeMapSolution
    {
        /// <summary>
        /// SortedDict изи делается, но медленный. Для более быстрого решения суть та же, только храним список вместо SortedDict, а в Get реализуем бинарный поиск по списку с условием list.timestamp <= arg_timestamp. 
        /// </summary>
        public class TimeMap_SortedDict
        {

            private readonly Dictionary<string, SortedDictionary<int, string>> _dictionary;

            public TimeMap_SortedDict()
            {
                _dictionary = new Dictionary<string, SortedDictionary<int, string>>();
            }

            public void Set(string key, string value, int timestamp)
            {
                if (_dictionary.TryGetValue(key, out var timeMap))
                {
                    timeMap[timestamp] = value;
                }
                else
                {
                    _dictionary.Add(key, new SortedDictionary<int, string>() { { timestamp, value} });
                }
            }

            /// <summary>
            /// Returns a value such that set was called previously, with timestamp_prev <= timestamp. If there are multiple such values, it returns the value associated with the largest timestamp_prev. If there are no values, it returns "".
            /// </summary>
            public string Get(string key, int timestamp)
            {

                if (_dictionary.TryGetValue(key, out var timeMap))
                {
                    var timedPair = timeMap.Where(i => i.Key <= timestamp)
                        .OrderByDescending(i => i.Key)
                        .FirstOrDefault();
                    if (string.IsNullOrEmpty(timedPair.Value))
                    {
                        return string.Empty;
                    }
                    else
                    {
                        return timedPair.Value;
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
