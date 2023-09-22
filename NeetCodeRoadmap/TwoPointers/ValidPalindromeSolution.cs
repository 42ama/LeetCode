using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.TwoPointers
{
    internal class ValidPalindromeSolution
    {
        public bool IsPalindrome(string s)
        {
            if (s.Length < 2) { return true; }

            var rightPointerDelta = 0;
            while (s.Length - 1 - rightPointerDelta > 0 && !Char.IsLetterOrDigit(s[s.Length - 1 - rightPointerDelta]))
            {
                rightPointerDelta++;
            } 
            var iterateUntil = s.Length;
            for (int leftPointer = 0; leftPointer < iterateUntil; leftPointer++)
            {
                var currentChar = s[leftPointer];
                if (Char.IsLetterOrDigit(currentChar))
                {
                    var lowerLetter = Char.ToLower(currentChar);
                    var lowerOtherLetter = Char.ToLower(s[s.Length - 1 - rightPointerDelta]);
                    if (lowerLetter != lowerOtherLetter)
                    {
                        return false;
                    }

                    do
                    {
                        rightPointerDelta++;
                    } while (s.Length - 1 - rightPointerDelta > 0 && !Char.IsLetterOrDigit(s[s.Length - 1 - rightPointerDelta]));
                }
            }

            return true;
        }
    }
}
