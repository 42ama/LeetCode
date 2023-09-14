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
            while (true)
            {
                var reachNMileThisIteration = new Dictionary<int, List<int>>();
                var processedCarCounter = 0;

                for (int currentCarIndex = 0; currentCarIndex < numberOfCars; currentCarIndex++)
                {
                    if (position[currentCarIndex] == target)
                    {
                        processedCarCounter++;
                        if (processedCarCounter == numberOfCars)
                        {
                            return fleetCount;
                        }
                        else
                        {
                            continue;
                        }                        
                    }

                    position[currentCarIndex] = Math.Clamp(position[currentCarIndex] + speed[currentCarIndex], 0, target);

                    if (reachNMileThisIteration.TryGetValue(position[currentCarIndex], out var cars))
                    {
                        if (position[currentCarIndex] != target)
                        {
                            foreach (var otherCarIndex in cars)
                            {
                                if (speed[currentCarIndex] > speed[otherCarIndex])
                                {
                                    speed[currentCarIndex] = speed[otherCarIndex];
                                }
                                else
                                {
                                    speed[otherCarIndex] = speed[currentCarIndex];
                                }
                            }
                        }

                        cars.Add(currentCarIndex);
                    }
                    else
                    {
                        reachNMileThisIteration.Add(position[currentCarIndex], new List<int> { currentCarIndex });
                    }
                }

                fleetCount += reachNMileThisIteration.Count(i => i.Key == target);
            }
        }
    }
}
