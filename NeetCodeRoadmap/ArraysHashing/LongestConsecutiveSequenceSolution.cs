using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
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
                var isAddedAnywhere = false;
                foreach (var candidateSet in listOfCandidates)
                {
                    if (candidateSet.Contains(prevNumber) || candidateSet.Contains(nextNumber))
                    {
                        candidateSet.Add(currentNumber);
                        isAddedAnywhere = true;
                    }
                }

                if (!isAddedAnywhere)
                {
                    listOfCandidates.Add(new SortedSet<int> { currentNumber });
                }
            }

            foreach (var candidateSet in listOfCandidates)
            {
                var currentSetFirst = candidateSet.First();
                var currentSetLast = candidateSet.Last();
                foreach (var anotherCandidateSet in listOfCandidates)
                {
                    if (candidateSet == anotherCandidateSet) { continue; }

                    if (anotherCandidateSet.Contains(currentSetFirst) ||  anotherCandidateSet.Contains(currentSetLast))
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
