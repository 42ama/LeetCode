using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing.Round2
{
    internal class GroupAnagramsSolution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var charArray = str.ToCharArray();
                Array.Sort(charArray);
                var key = new string(charArray);
                if (dict.TryGetValue(key, out var annagramsList))
                {
                    annagramsList.Add(str);   
                }
                else
                {
                    dict.Add(key, new List<string> { str });
                }
            }

            return new List<IList<string>>(dict.Values);
        }
    }
}
