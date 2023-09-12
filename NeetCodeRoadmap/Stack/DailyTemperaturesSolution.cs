using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    internal class DailyTemperaturesSolution
    {
        /// <summary>
        /// Набираем стек пока не найдём температуру больше текущей, после проверяем все элементы из стека. Для тех которые меньше устанавливаем дальность в ответ, остальные оставляем в стеке. После основного прохода проходимся по стеку - дочищаем элементы которым не нашлось более теплого дня.
        /// </summary>
        public int[] DailyTemperatures(int[] temperatures)
        {
            var result = new int[temperatures.Length];

            var stack = new Stack<(int, int)>();
            stack.Push((temperatures[0], 0));

            for (int i = 1; i < result.Length; i++)
            {
                var current = temperatures[i];
                var previous = temperatures[i - 1];
                if (current > previous)
                {
                    while (stack.Count > 0)
                    {
                        var stackPrevious = stack.Peek();

                        if (current > stackPrevious.Item1)
                        {
                            result[stackPrevious.Item2] = i - stackPrevious.Item2;
                            stack.Pop();
                        }
                        else
                        {
                            // Нет смысла смотреть дальше
                            break;
                        }
                    }
                }

                stack.Push((current, i));
            }

            return result;
        }
    }
}
