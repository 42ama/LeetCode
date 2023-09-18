using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Stack
{
    internal class CarFleetSolution
    {
        public int CarFleet(int target, int[] position, int[] speed)
        {
            var numberOfCars = position.Length;
            var fleetCount = 0;
            var reachDestinationAt = new float[numberOfCars];

            // 1. Разбиваем на пары позиция+скорость
            // 2. Сортируем, наибольшая позиция впереди

            var joined = new List<Car>(numberOfCars);
            for (int i = 0; i < numberOfCars; i++)
            {
                joined.Add(new Car { Postion = position[i], Speed = speed[i] });
            }
            joined.Sort();

            // 3. Для каждой машины считаем (S - currentPos)/ speed - время доезжания до цели
            var checkStack = new Stack<float>();
            foreach (var car in joined)
            {
                var time = Convert.ToSingle(target - car.Postion) / car.Speed;

                if (checkStack.Count == 0)
                {
                    checkStack.Push(time);
                    continue;
                }

                // 4. Складываем время доезжания в descending stack
                var topTime = checkStack.Peek();
                if (time <= topTime)
                {
                    // 5.1 Если оно меньше или равно, чем последнее хранящееся в стеке, то считаем что эта машина присоединилась к флоту и ей можно принебречь
                }
                else
                {
                    // 5.2 Если оно больше тогда такая машина доезжает отдельно - запишем её в стек, как новый "стопор"
                    checkStack.Push(time);
                }
            }

            return checkStack.Count;
        }

        public struct Car : IComparable<Car>, IEquatable<Car>
        {
            public int Postion;
            public float Speed;

            int IComparable<Car>.CompareTo(Car other)
            {
                if (Postion > other.Postion)
                {
                    return -1;
                }
                else if (Postion < other.Postion)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            bool IEquatable<Car>.Equals(Car other)
            {
                return Postion == other.Postion && Speed == other.Speed;
            }

            public override string ToString()
            {
                return $"({Postion}, {Speed}";
            }
        }
    }
}
