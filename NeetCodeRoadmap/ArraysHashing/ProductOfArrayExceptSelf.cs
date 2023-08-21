using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeetCodeRoadmap.ArraysHashing
{
    /// <summary>
    /// https://leetcode.com/problems/product-of-array-except-self/
    /// </summary>
    internal class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            // Инициализируем единицами
            //Array.Fill(result, 1);
            new Span<int>(result).Fill(1);


            var accum = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] *= accum; // Заполняем предыдущий аккумулятор
                accum *= nums[i]; // Записываем новый
            }

            accum = 1;
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                result[i] *= accum; // Заполняем предыдущий аккумулятор
                accum *= nums[i]; // Записываем новый
            }

            return result;
        }
    }
}
