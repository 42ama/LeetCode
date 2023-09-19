using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    internal class LargestRectangleAreaBetterSolution
    {
        public int LargestRectangleArea(int[] heights)
        {
            var stack = new Stack<Rectangle>();
            var currentMax = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                var currentRectHeight = heights[i];
                if (stack.Count > 0)
                {
                    var stackedRect = stack.Peek();
                    
                    // Прерываем набор в случае если новые Rect ниже существующего, ищем в стеке подходящий
                    if (currentRectHeight < stackedRect.Height)
                    {
                        var challangeMax = stack.Count * currentRectHeight;
                        if (challangeMax > currentMax)
                        {
                            currentMax = challangeMax;
                        }

                        while (true)
                        {
                            // Здесь некорректный warning - stack может очиститься за цикл.
                            if (stack.Count == 0) { break; }

                            var popped = stack.Pop();
                            var challngeHeight = (stack.Count + 1) * popped.Height; // Хуйня какая-то нерабочая
                            if (challngeHeight > currentMax)
                            {
                                currentMax = challangeMax;
                            }

                            if (currentRectHeight >= popped.Height) { break; }
                        }
                    }
                }

                stack.Push(new Rectangle { Height = currentRectHeight, Position = i });
            }

            if (stack.Count > 0)
            {
                var stackedRect = stack.Peek();
                var challangeMax = stack.Count * stackedRect.Height;
                if (challangeMax > currentMax)
                {
                    currentMax = challangeMax;
                }
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
