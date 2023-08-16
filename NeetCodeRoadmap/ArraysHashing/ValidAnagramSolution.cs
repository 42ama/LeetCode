using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    internal class ValidAnagramSolution
    {
        /// <param name="s">Original word</param>
        /// <param name="t">Checking against anagram</param>
        /// <returns>t is anagram for c</returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) { return false; }

            var sLetters = FormMapForWord(s);

            foreach (var letter in t)
            {
                if (!sLetters.TryGetValue(letter, out var value))
                {
                    return false;
                }

                if (value == 1)
                {
                    sLetters.Remove(letter);
                }
                else
                {
                    sLetters[letter] -= 1;
                }
            }

            return true;
        }

        private Dictionary<char, int> FormMapForWord(string word)
        {
            var wordLetters = new Dictionary<char, int>();
            foreach (var letter in word)
            {
                if (wordLetters.ContainsKey(letter))
                {
                    wordLetters[letter] += 1;
                }
                else
                {
                    wordLetters.Add(letter, 1);
                }
            }

            return wordLetters;
        }
    }
}
