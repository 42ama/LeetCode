using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    internal class ValidParenthesesSolution
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            var leftElemnts = new HashSet<char> { '(', '[', '{' };
            var corresponidng = new Dictionary<char, char>
            {
                {')', '(' },
                {']', '[' },
                {'}', '{' }
            };

            foreach (char symbol in s)
            {
                if (leftElemnts.Contains(symbol))
                {
                    stack.Push(symbol);
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    var stackedElemnt = stack.Pop();
                    if (corresponidng[symbol] != stackedElemnt)
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
