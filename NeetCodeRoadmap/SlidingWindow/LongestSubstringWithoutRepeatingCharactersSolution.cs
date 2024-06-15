using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.SlidingWindow
{
    internal class LongestSubstringWithoutRepeatingCharactersSolution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var maxLengthFound = 0;
            var visitedCharactersSet = new HashSet<char>(s.Length);
            var visitedCharactersQueue = new Queue<char>(s.Length);

            foreach (char c in s)
            {
                if (visitedCharactersSet.Contains(c))
                {
                    if (visitedCharactersSet.Count > maxLengthFound)
                    {
                        maxLengthFound = visitedCharactersSet.Count;
                    }

                    while (visitedCharactersSet.Contains(c) && visitedCharactersQueue.Count > 0)
                    {
                        var removed = visitedCharactersQueue.Dequeue();
                        visitedCharactersSet.Remove(removed);
                    }
                }

                visitedCharactersSet.Add(c);
                visitedCharactersQueue.Enqueue(c);
            }

            if (visitedCharactersSet.Count > maxLengthFound)
            {
                maxLengthFound = visitedCharactersSet.Count;
            }

            return maxLengthFound;
        }
    }
}
