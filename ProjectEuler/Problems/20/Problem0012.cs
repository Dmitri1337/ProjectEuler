using System.Linq;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Highly divisible triangular number
    /// </summary>
    public class Problem0012
    {
        public object GetResult()
        {
            int addend = 3;
            int number = 3;
            int numberOfFactors = 2;

            while (numberOfFactors < 500)
            {
                number += addend;
                addend++;

                numberOfFactors = number.GetProperDivisors().Count() + 1;
            }

            return number;
        }
    }
}