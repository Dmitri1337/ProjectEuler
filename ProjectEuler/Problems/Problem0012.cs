using System.Linq;
using ProjectEuler.Math;

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

                numberOfFactors = Primes.Factorize(number)
                    .Select(x => x.Power + 1)
                    .Aggregate(1, (a, b) => a * b);
            }

            return number;
        }
    }
}