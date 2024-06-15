using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack.Round2
{
    internal class DailyTemperaturesSolution
    {
        // slow
        public int[] DailyTemperatures_1(int[] temperatures)
        {
            var result = new int[temperatures.Length];

            var max = int.MinValue;

            for (int i = temperatures.Length - 1; i >= 0; i--)
            {
                var current = temperatures[i];

                if (current >= max)
                {
                    max = current;
                    result[i] = 0;
                    continue;
                }

                // current < max
                for (int j = i + 1; j < temperatures.Length; j++)
                {
                    var candidate = temperatures[j];

                    if (candidate > current)
                    {
                        result[i] = j - i;
                        break;
                    }
                }
            }

            return result;
        }


        // Почти докрутил, см решение Round_1, там всё понятно. на одном стеке нужно хранить и темпу, и индекс.
        public int[] DailyTemperatures_2(int[] temperatures)
        {
            // todo args valid

            var result = new int[temperatures.Length];

            var stack = new Stack<int>();

            stack.Push(temperatures[0]); // todo include in args valid

            for (int i = 1; i < temperatures.Length; i++)
            {
                var current = temperatures[i];
                
                if (stack.Count == 0) { stack.Push(current); }

                var previous = stack.Peek(); // todo TryPeek

                if (current > previous)
                {
                    var poppedCount = 0;
                    while (stack.Count > 0 && stack.Peek() < current)
                    {
                        stack.Pop();
                        poppedCount++;
                        result[i - poppedCount] = poppedCount;
                    }
                }

                stack.Push(current);
            }

            return result;
        }
    }
}
