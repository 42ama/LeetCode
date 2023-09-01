using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    /// <summary>
    /// Input: tokens = ["4","13","5","/","+"]
    /// Output: 6
    /// Explanation: (4 + (13 / 5)) = 6
    /// </summary>
    internal class EvaluateReversePolishNotationSolution
    {
        public int EvalRPN(string[] tokens)
        {
            var numbersStack = new Stack<int>();
            for (int tokenIndex = 0; tokenIndex < tokens.Length; tokenIndex++)
            {
                var currentToken = tokens[tokenIndex];

                int number1, number2;
                switch (currentToken)
                {
                    case Const.Plus:
                        number1 =  numbersStack.Pop();
                        number2 = numbersStack.Pop();
                        numbersStack.Push(number1 + number2);
                        break;

                    case Const.Minus:
                        number1 = numbersStack.Pop();
                        number2 = numbersStack.Pop();
                        numbersStack.Push(number2 - number1);
                        break;

                    case Const.Multiply:
                        number1 = numbersStack.Pop();
                        number2 = numbersStack.Pop();
                        numbersStack.Push(number1 * number2);
                        break;

                    case Const.Divide:
                        number1 = numbersStack.Pop();
                        number2 = numbersStack.Pop();
                        numbersStack.Push(number2 / number1);
                        break;

                    default:
                        var currentNumber = int.Parse(currentToken);
                        numbersStack.Push(currentNumber);
                        break;
                }
            }
            return numbersStack.Pop();
        }

        private static class Const
        {
            public const string Plus = "+";

            public const string Minus = "-";

            public const string Multiply = "*";

            public const string Divide = "/";
        }
    }
}
