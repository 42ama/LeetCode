using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers.Round2
{
    internal class TwoSumIISolution
    {
        // leetcode too long
        public int[] TwoSum_1(int[] numbers, int target)
        {
            if (numbers.Length < 2) { throw new ArgumentException($"{nameof(numbers)} length must be greater than 2"); }

            var leftPointer = 0;
            var rightPointer = 1;

            while (leftPointer < numbers.Length - 1)
            {
                var leftValue = numbers[leftPointer];
                var rightValue = numbers[rightPointer];

                if (leftValue + rightValue == target)
                {
                    // В ответе требуется, чтобы индекс считался от единицы.
                    return new int[] { leftPointer + 1, rightPointer + 1};
                }
                else if (rightPointer + 1 == numbers.Length)
                {
                    leftPointer++;
                    rightPointer = leftPointer + 1;
                }
                else
                {
                    rightPointer++;
                }
            }


            throw new InvalidDataException("Must be strictly one answer");
        }

        public int[] TwoSum_2(int[] numbers, int target)
        {
            if (numbers.Length < 2) { throw new ArgumentException($"{nameof(numbers)} length must be greater than 2"); }

            var leftPointer = 0;
            var rightPointer = numbers.Length - 1;

            while (true)
            {
                var leftValue = numbers[leftPointer];
                var rightValue = numbers[rightPointer];

                var resultOfMatching = target - rightValue - leftValue;

                if (resultOfMatching == 0)
                {
                    // В ответе требуется, чтобы индекс считался от единицы.
                    return new int[] { leftPointer + 1, rightPointer + 1 };
                }
                else if (resultOfMatching > 0)
                {
                    leftPointer++;
                }
                else // resultOfMatching < 0
                {
                    rightPointer--;
                }
            }

            throw new InvalidDataException("Must be strictly one answer");
        }
    }
}
