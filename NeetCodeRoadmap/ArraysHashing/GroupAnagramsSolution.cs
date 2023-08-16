using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    internal class GroupAnagramsSolution
    {
        /// <param name="strs">Массив строк</param>
        /// <returns>Среди строк найденные анаграммы сгруппированные вместе</returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            // Key - длина слова, value - слово (или что-то другое уже).
            var dictByLength = new Dictionary<int, string>();
            foreach (var word in strs)
            {
                if (dictByLength.ContainsKey(word.Length))
                {

                }
            }
        }

        private bool IsAnagram(string s, string t)
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
