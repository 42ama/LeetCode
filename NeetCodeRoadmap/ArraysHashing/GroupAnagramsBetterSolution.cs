using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    /// <summary>
    /// https://leetcode.com/problems/group-anagrams/
    /// </summary>
    internal class GroupAnagramsBetterSolution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var dict = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var hash = GetHash(str);
                if (dict.ContainsKey(hash))
                {
                    dict[hash].Add(str);
                }
                else
                {
                    dict.Add(hash, new List<string> { str });
                }
            }


            return dict.Values.ToList();
        }

        private string GetHash(string word)
        {
            // Since word can contain only lowercase English letters we can do this trick.
            // Creating an char[26] array for counting letters of the word.
            var key = new char[26];
            foreach (var letter in word)
            {
                key[letter - 'a']++; // This is heart of the trick.
            }

            return new string(key); // new string(char[]) и char[].ToString() Отличаются !!!
        }
    }
}
