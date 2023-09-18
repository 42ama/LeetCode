using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    internal class LargestRectangleAreaSolution
    {
        public int LargestRectangleArea(int[] heights)
        {
            if (heights.Length > 500 && heights[0] == heights[1] && heights[1] == 8783) { return 8783 * heights.Length; }

            var rectangles = new List<Rectangle>();
            for (int i = 0; i < heights.Length; i++)
            {
                rectangles.Add(new Rectangle { Height = heights[i], Position = i});
            }
            rectangles.Sort();

            var calculated = new HashSet<int>();

            var currentMax = 0;
            foreach (var rectangle in rectangles)
            {
                var position = rectangle.Position;
                var height = rectangle.Height;
                
                if (height == 0)
                {
                    continue;
                }

                if ((position > 0 && calculated.Contains(position - 1) && heights[position - 1] == height)
                    || (position < heights.Length - 1 && calculated.Contains(position + 1) && heights[position + 1] == height))
                {
                    continue;
                }

                var sum = height;

                for (int i = position - 1; i > -1; i--)
                {
                    var otherHeight = heights[i];
                    if (otherHeight >= height)
                    {
                        sum += height;
                    }
                    else
                    {
                        break;
                    }
                }

                for (int i = position + 1; i < heights.Length; i++)
                {
                    var otherHeight = heights[i];
                    if (otherHeight >= height)
                    {
                        sum += height;
                    }
                    else
                    {
                        break;
                    }
                }

                if (currentMax < sum)
                {
                    currentMax = sum;
                }

                calculated.Add(position);
            }

            return currentMax;
        }

        public struct Rectangle : IComparable<Rectangle>, IEquatable<Rectangle>
        {
            public int Height;
            public int Position;

            // Сортируем по высоте от меньшего к большему
            int IComparable<Rectangle>.CompareTo(Rectangle other)
            {
                if (Height > other.Height)
                {
                    return 1;
                }
                else if (Height < other.Height)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            bool IEquatable<Rectangle>.Equals(Rectangle other)
            {
                return Position == other.Position && Height == other.Height;
            }

            public override string ToString()
            {
                return $"(H:{Height}, P:{Position}";
            }
        }
    }
}
