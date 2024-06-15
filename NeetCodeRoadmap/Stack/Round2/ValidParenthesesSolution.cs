using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack.Round2
{
    internal class ValidParenthesesSolution
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();

            var brackets = new Dictionary<char, char>
            {
                { '(', ')' },
                { '{', '}' },
                { '[', ']' },
            };

            foreach (var currentCharacter in s)
            {
                if (brackets.ContainsKey(currentCharacter))
                {
                    // Если это ключ, то это левая скобка.
                    stack.Push(currentCharacter);
                }
                else
                {
                    // Иначе это правая скобка.
                    var isPopped = stack.TryPop(out var leftBracket);
                    if (!isPopped) { return false; }

                    if (brackets.TryGetValue(leftBracket, out var mustMatchRightBracket))
                    {
                        if (currentCharacter != mustMatchRightBracket)
                        {
                            return false;
                        }
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}
