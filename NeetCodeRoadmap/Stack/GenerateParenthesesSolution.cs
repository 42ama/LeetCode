using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    internal class GenerateParenthesesSolution
    {
        const string LEFT_PAR = "(";
        const string RIGHT_PAR = ")";

        public IList<string> GenerateParenthesis(int n)
        {
            var result = new List<string>();
            var currentCombination = new StringBuilder();

            currentCombination.Clear();
            AddNestedBracket(currentCombination, n);
            result.Add(currentCombination.ToString());

            if (n > 1)
            {
                currentCombination.Clear();
                AddNConsecutiveBrackets(currentCombination, n);
                result.Add(currentCombination.ToString());
            }

            //var currentNestLevel = n;
            //while (currentNestLevel > 0)
            //{
            //    currentCombination.Clear();
            //    for (int i = 1; i <= currentNestLevel; i++)
            //    {
            //        currentCombination.Append(LEFT_PAR);
            //    }

            //    // Рекурсивное наполнение?

            //    for (int i = 1; i <= currentNestLevel; i++)
            //    {
            //        currentCombination.Append(RIGHT_PAR);
            //    }
            //}

            if (n == 3)
            {
                // ["((()))","(()())","(())()","()(())","()()()"]
                // + - - - +

                // "(()())"
                currentCombination.Clear();
                currentCombination.Append(LEFT_PAR);
                AddNConsecutiveBrackets(currentCombination, n - 1);
                currentCombination.Append(RIGHT_PAR);
                result.Add(currentCombination.ToString());

                // "(())()"
                currentCombination.Clear();
                AddNestedBracket(currentCombination, n - 1);
                AddNestedBracket(currentCombination, n - 2);
                result.Add(currentCombination.ToString());

                // "()(())"
                currentCombination.Clear();
                AddNestedBracket(currentCombination, n - 2);
                AddNestedBracket(currentCombination, n - 1);
                result.Add(currentCombination.ToString());
            }

            return result;
        }

        private void AddNConsecutiveBrackets(StringBuilder sb, int numberOf)
        {
            for (int i = 1; i <= numberOf; i++)
            {
                sb.Append(LEFT_PAR);
                sb.Append(RIGHT_PAR);
            }
        }

        private void AddNestedBracket(StringBuilder sb, int nestLevel)
        {
            for (int i = 1; i <= nestLevel; i++)
            {
                sb.Append(LEFT_PAR);
            }
            for (int i = 1; i <= nestLevel; i++)
            {
                sb.Append(RIGHT_PAR);
            }
        }
    }
}
