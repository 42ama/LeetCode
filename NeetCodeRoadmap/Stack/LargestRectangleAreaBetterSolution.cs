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
            // Может передлать на descendig stack и на каждой итерации считать? 
            var stackArr = new int[heights.Length];
            var stackArrPointer = 0;

            var currentMax = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                var currentRectHeight = heights[i];
                if (stackArrPointer > 0)
                {
                    var stackedRectHeight = stackArr[stackArrPointer - 1];

                    var poppedCount = 0;
                    // Прерываем набор в случае если новые Rect ниже существующего, ищем в стеке подходящий
                    if (currentRectHeight < stackedRectHeight)
                    {
                        var savedPointerPosition = stackArrPointer;
                        while (true)
                        {
                            // Здесь некорректный warning - stack может очиститься за цикл.
                            if (stackArrPointer == 0) { break; }

                            var poppedHeight = stackArr[stackArrPointer - 1];
                            if (currentRectHeight < poppedHeight)
                            {
                                stackArr[stackArrPointer - 1] = currentRectHeight;
                            }
                            
                            stackArrPointer--;

                            poppedCount++;
                            var challngeHeight = poppedCount * poppedHeight;
                            if (challngeHeight > currentMax)
                            {
                                currentMax = challngeHeight;
                            }

                            if (currentRectHeight >= poppedHeight) { break; }
                        }
                        stackArrPointer = savedPointerPosition;
                    }
                }

                stackArr[stackArrPointer] = currentRectHeight;
                stackArrPointer++;
            }

            var poppedCountOuter = 0;
            while (true)
            {
                // Здесь некорректный warning - stack может очиститься за цикл.
                if (stackArrPointer == 0) { break; }

                var poppedHeight = stackArr[stackArrPointer - 1];
                stackArrPointer--;

                poppedCountOuter++;
                var challngeHeight = poppedCountOuter * poppedHeight;
                if (challngeHeight > currentMax)
                {
                    currentMax = challngeHeight;
                }
            }

            return currentMax;
        }
    }
}
