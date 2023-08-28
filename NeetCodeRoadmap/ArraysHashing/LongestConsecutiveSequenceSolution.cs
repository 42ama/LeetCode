using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    [Obsolete("Слабое решение, см BetterSolution")]
    internal class LongestConsecutiveSequenceSolution
    {
        // You must write an algorithm that runs in O(n) time.
        public int LongestConsecutive(int[] nums)
        {
            if (nums.Length == 0) { return 0; }

            var listOfCandidates = new List<SortedSet<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                var currentNumber = nums[i];
                var prevNumber = currentNumber - 1;
                var nextNumber = currentNumber + 1;

                var addedSets = new List<SortedSet<int>>();
                foreach (var candidateSet in listOfCandidates)
                {
                    if (candidateSet.Contains(prevNumber) || candidateSet.Contains(nextNumber))
                    {
                        candidateSet.Add(currentNumber);

                        foreach (var addedSet in addedSets)
                        {
                            foreach (var item in addedSet)
                            {
                                candidateSet.Add(item);
                            }
                        }

                        addedSets.Add(candidateSet);
                    }
                }

                if (addedSets.Count == 0)
                {
                    listOfCandidates.Add(new SortedSet<int> { currentNumber });
                }
            }

            for (int i = 0; i < listOfCandidates.Count; i++)
            {
                var candidateSet = listOfCandidates[i];
                var currentSetFirst = candidateSet.First();
                var currentSetLast = candidateSet.Last();
                for (int j = 0; j < listOfCandidates.Count; j++)
                {
                    var anotherCandidateSet = listOfCandidates[j];
                    if (i == j) { continue; }

                    if (anotherCandidateSet.Contains(currentSetFirst) || anotherCandidateSet.Contains(currentSetLast))
                    {
                        foreach (var item in anotherCandidateSet)
                        {
                            candidateSet.Add(item);
                        }
                    }
                }
            }

            return listOfCandidates.Max(i => i.Count);
        }   
    }
}
