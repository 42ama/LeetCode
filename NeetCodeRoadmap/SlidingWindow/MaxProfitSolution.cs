using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.SlidingWindow
{
    internal class MaxProfitSolution
    {
        public int MaxProfit(int[] prices)
        {
            var maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                var buyingPrice = prices[i];
                for (int j = i + 1; j < prices.Length; j++)
                {
                    var sellingPrice = prices[j];

                    var candidateProfit = sellingPrice - buyingPrice;
                    if (candidateProfit > maxProfit)
                    {
                        maxProfit = candidateProfit;
                    }
                }
            }

            return maxProfit;
        }

        public int MaxProfit_2(int[] prices)
        {
            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                int currPrice = prices[i];
                minPrice = Math.Min(minPrice, currPrice);
                maxProfit = Math.Max(maxProfit, currPrice - minPrice);
            }
            return maxProfit;
        }
    }
}
