using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Amicable numbers
    /// </summary>
    public class Problem0021
    {
        public object GetResult()
        {
            var amicableNumbers = new HashSet<int>();

            for (int i = 1; i < 10000; i++)
            {
                if (amicableNumbers.Contains(i))
                    continue;

                if (!IsAmicableNumber(i, out int pair))
                    continue;

                amicableNumbers.Add(i);
                amicableNumbers.Add(pair);
            }

            return amicableNumbers.Sum();
        }

        private static bool IsAmicableNumber(int n, out int pair)
        {
            if (n == 1)
            {
                pair = 0;
                return false;
            }

            int b = Primes.GetProperDivisors(n).Sum();
            int a = Primes.GetProperDivisors(b).Sum();

            if (a == b)
            {
                pair = 0;
                return false;
            }

            if (a == n)
            {
                pair = b;
                return true;
            }

            pair = 0;
            return false;
        }
    }
}