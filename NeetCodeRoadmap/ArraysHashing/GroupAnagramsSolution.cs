using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing_
{
    [Obsolete("Слабое решение, см BetterSolution")]
    internal class GroupAnagramsSolution
    {
        private Dictionary<string, Dictionary<char, int>> _wordMapCache = new Dictionary<string, Dictionary<char, int>>();

        /// <param name="strs">Массив строк</param>
        /// <returns>Среди строк найденные анаграммы сгруппированные вместе</returns>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var previousWords = new List<List<string>>();

            // Берём слово word из strs
            foreach (var word in strs)
            {
                var isAnyFound = false;
                // Проверяем его относительно всех запомненных ранее слов
                foreach (var previousWordList in previousWords)
                {
                    // Из каждого сета достаточно взять один элемент.
                    var first = previousWordList.First();
                    var isAnagram = IsAnagram(first, word);

                    // Если нашли анаграму, то прекращаем поиск и кладём слово в тот же сет, где и была анаграма
                    if (isAnagram)
                    {
                        previousWordList.AddSorted(word);
                        isAnyFound = true;
                        break;
                    }
                }

                if (!isAnyFound)
                {
                    // Если не нашли, то создаём новый сет
                    previousWords.Add(new List<string> { word });
                }
            }

            var result = new List<IList<string>>();
            foreach (var list in previousWords)
            {
                result.Add(list);
            }

            return result;
        }

        private bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) { return false; }
            if (s.Length < 2) { return s == t; } // Так будет быстрее запроцессить часть случаев

            Dictionary<char, int> sLetters;
            if (_wordMapCache.ContainsKey(s))
            {
                sLetters = _wordMapCache[s].ToDictionary(i => i.Key, i => i.Value);
            }
            else
            {
                sLetters = FormMapForWord(s);
                _wordMapCache[s] = sLetters.ToDictionary(i => i.Key, i => i.Value);
            }

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

    public static class ListExt
    {
        public static void AddSorted<T>(this List<T> @this, T item) where T : IComparable<T>
        {
            if (@this.Count == 0)
            {
                @this.Add(item);
                return;
            }
            if (@this[@this.Count - 1].CompareTo(item) <= 0)
            {
                @this.Add(item);
                return;
            }
            if (@this[0].CompareTo(item) >= 0)
            {
                @this.Insert(0, item);
                return;
            }
            int index = @this.BinarySearch(item);
            if (index < 0)
                index = ~index;
            @this.Insert(index, item);
        }
    }
}

