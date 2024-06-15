using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.BinarySearch
{
    internal class EatingBananasSolution
    {
        public int MinEatingSpeed(int[] piles, int h)
        {
            var max = piles.Max();
            if (h == piles.Length)
            {
                return max;
            }

            var lowerBound = 0;
            var upperBound = max;

            var minAchivedSpeed = max;

            while (true)
            {
                var candidateSpeed = (lowerBound + upperBound) / 2;

                if (candidateSpeed <= lowerBound)
                {
                    return minAchivedSpeed;
                }

                var candidateHoursSpent = 0;
                foreach (var pile in piles)
                {
                    candidateHoursSpent += (int)Math.Ceiling((double)pile / candidateSpeed);

                    if (candidateHoursSpent > h)
                    {
                        lowerBound = candidateSpeed;
                        break;
                    }
                }

                if (candidateHoursSpent <= h)
                {
                    minAchivedSpeed = candidateSpeed;
                    upperBound = candidateSpeed;
                }

            }
        }
    }
}
