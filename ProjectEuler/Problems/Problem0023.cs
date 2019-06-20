using System.Linq;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Non-abundant sums
    /// </summary>
    public class Problem0023
    {
        public object GetResult()
        {
            const int max = 28123;

            int[] abundantNumbers = Enumerable.Range(1, max).Where(IsAbundantNumber).OrderBy(x => x).ToArray();
            int[] nonAbundantSums = Enumerable.Range(0, max + 1).ToArray();

            for (int a = 0; a < abundantNumbers.Length; a++)
            for (int b = a; b < abundantNumbers.Length; b++)
            {
                int abundantSum = abundantNumbers[a] + abundantNumbers[b];
                if (abundantSum < nonAbundantSums.Length)
                    nonAbundantSums[abundantSum] = 0;
            }

            return nonAbundantSums.Sum();
        }

        private static bool IsAbundantNumber(int number)
        {
            return number.GetProperDivisors().Sum() > number;
        }
    }
}