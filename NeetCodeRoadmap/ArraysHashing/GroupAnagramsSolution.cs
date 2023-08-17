using System;
using System.Collections;
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
            var previousWords = new List<List<string>>();

            // Берём слово word из strs
            foreach (var word in strs)
            {
                var isAnyFound = false;
                // Проверяем его относительно всех запомненных ранее слов
                foreach (var previousWordSet in previousWords)
                {
                    // Из каждого сета достаточно взять один элемент.
                    var first = previousWordSet.First();
                    var isAnagram = IsAnagram(first, word);

                    // Если нашли анаграму, то прекращаем поиск и кладём слово в тот же сет, где и была анаграма
                    if (isAnagram)
                    {
                        previousWordSet.Add(word);
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
                list.Sort();
                result.Add(list);
            }

            return result;
        }

        private bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) { return false; }
            if (s.Length < 2) { return s == t; } // Так будет быстрее запроцессить часть случаев

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
