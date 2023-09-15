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
            // 3. Для каждой машины считаем (S - currentPos)/ speed - время доезжания до цели
            // 4. Складываем время доезжания в descending stack
            // 5. Считаем время для следующей машины:
            // 5.1 Если оно больше или равно чем последнее хранящееся в стеке, то считаем что эта машина присоединилась к флоту и ей можно принебречь
            // 5.2 Если оно меньше, то тогда такая машина доезжает отдельно - запишем её в стек, как новый "стопор"

            while (true)
            {
                for (int currentCarIndex = 0; currentCarIndex < numberOfCars; currentCarIndex++)
                {
                    reachDestinationAt[currentCarIndex] = Convert.ToSingle(target - position[currentCarIndex]) / speed[currentCarIndex];
                }

                for (int currentCarIndex = 0; currentCarIndex < numberOfCars; currentCarIndex++)
                {
                    reachDestinationAt[currentCarIndex] = Convert.ToSingle(target) / speed[currentCarIndex];
                }
            }
        }
    }
}
