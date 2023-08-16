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
            var dictByLength = new Dictionary<int, IList<string>>();

            var setOfWords = new HashSet<IList<string>>();
            foreach (var word in strs)
            {
                if (dictByLength.TryGetValue(word.Length, out var wordsWithSameLength))
                {
                    var wordLettersMap = FormMapForWord(word);

                    foreach (var wordWithSameLength in wordsWithSameLength)
                    {
                        var isAnagram = IsAnagram(wordLettersMap, wordWithSameLength);
                    }
                }
                else
                {
                    dictByLength.Add(word.Length, new List<string> { word });
                }
            }
        }

        private bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) { return false; }

            var sLetters = FormMapForWord(s);

            return IsAnagram(sLetters, t);
        }

        private bool IsAnagram(IDictionary<char, int> sLetters, string t)
        {
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
