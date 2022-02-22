using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata18_Sum_of_Factors_of_Factors
{
    class Program
    {
        static void Main(string[] args)
        {
            SumFF(69, 0); //➞ 3, 23 ➞ 0
            // Both 3 and 23 are prime numbers and have no factors
            // other than 1 and themselves so the result is 0.

            SumFF(12, 7); //➞ 2, 3, 4, 6 ➞ (0) + (0) + (2) + (2 + 3) ➞ 7

            SumFF(420, 1175); //➞ 2,4, 6, 10, 12... ➞ (2) + (2 + 3) + (2 + 5) + (2 + 3 + 4 + 6)... ➞ 1175

            SumFF(619, 0); //➞ ___ ➞ 0
            // 619 doesn't have any factors (other than 1 and 619).
        }

        /// <summary>
        /// Ever need the sum of the factors of factors? Well now you can get it!
        /// </summary>
        /// <param name="input">number greater than one</param>
        /// <param name="expected">the expected result</param>
        /// <returns>the sum of the factors factors</returns>
        private static int SumFF(int input, int expected)
        {
            List<int> factors = ListOfFactors(input);
            if (factors.Count == 0)
            {
                return 0;
            }

            int sum = 0;
            for (int i = 0; i < factors.Count; i++)
            {
                List<int> factorsFactors = ListOfFactors(factors[i]); factorsFactors.Sum();
                sum += factorsFactors.Sum();
            }

            Console.WriteLine($"input: {input}, sum: {sum}, expected: {expected}, same: {sum == expected}");
            return sum;
        }

        /// <summary>
        /// does not count 1 and the number itself
        /// </summary>
        /// <param name="input">A positive number over 0</param>
        /// <returns>A list of factors from the input</returns>
        private static List<int> ListOfFactors(int input)
        {
            List<int> result = new List<int>();
            //This algorythm isn't interested in the factors 1 and the input, so we start at 2 and only go to half the input
            for (int i = 2; i <= input / 2; i++)
            {
                //If you can divide a number with another without any remain, the second number is a factor of the first
                if (input % i == 0)
                {
                    result.Add(i);
                }
            }
            return result;
        }
    }
}
