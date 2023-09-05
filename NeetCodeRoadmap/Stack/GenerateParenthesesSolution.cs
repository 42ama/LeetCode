using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    internal class GenerateParenthesesSolution
    {
        const char LEFT_PAR = '(';
        const char RIGHT_PAR = ')';

        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            var currentCombination = new Stack<char>();

            void Backtrack(int openCount, int closedCount)
            {
                if (openCount == closedCount && openCount == n)
                {
                    result.Add(string.Join("", currentCombination));
                }
                if (openCount < n)
                {
                    currentCombination.Push(LEFT_PAR);
                    Backtrack(openCount + 1, closedCount);
                    currentCombination.Pop();
                }

                if (closedCount < openCount)
                {
                    currentCombination.Push(RIGHT_PAR);
                    Backtrack(openCount, closedCount + 1);
                    currentCombination.Pop();
                }
            }

            Backtrack(0, 0);

            return result;
        }
    }
}
