using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.Recursion
{
    internal class PowXNSolution
    {
        public double MyPow(double x, int n)
        {
            if (n == 1) { return x; }
            if (n == 0) { return 1; }
            if (n == -1) { return 1/x; }

            if (n > 0)
            {
                var isDivisableByTwo = n % 2 == 0;
                if (isDivisableByTwo)
                {
                    return MyPow(x, n / 2) * MyPow(x, n / 2);
                }
                else
                {
                    return x * MyPow(x, n - 1);
                }
                
            }
            else
            {
                return (1/x) * MyPow(x, n + 1);
            }
        }
    }
}
