using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers
{
    internal class TrappingRainWaterSolution
    {
        public int Trap(int[] height)
        {
            if (height.Length < 3) { return 0; }

            var pointer = 0;
            (int height, int position) current = (height[pointer], pointer);
            (int height, int position) top = current;

            var stack = new Stack<(int height, int position)>();
            var area = 0;

            stack.Push(current);
            pointer++;
            while (pointer < height.Length)
            {
                current = (height[pointer], pointer);

                if (current.height > top.height)
                {
                    while (true)
                    {
                        if (stack.Count == 0) { break; }
                        var pop = stack.Pop();

                        if (pop.position == top.position)
                        {
                            break;
                        }

                        area += top.height - pop.height;

                    }
                    top = current;
                }

                stack.Push(current);
                pointer++;
            }

            if (stack.Count == 0) { return area; }

            var right = stack.Pop();
            while (true)
            {
                if (stack.Count == 0) { break; }
                var pop = stack.Pop();
                if (pop.height < right.height)
                {
                    area += right.height - pop.height;
                }
                else
                {
                    right = pop;
                }
            }

            return area;
        }
    }
}
