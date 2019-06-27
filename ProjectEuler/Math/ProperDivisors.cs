using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Math
{
    public static partial class XXMath
    {
        public static IEnumerable<int> GetProperDivisors(this int n)
        {
            FactorizedNumber factorized = n.Factorize();
            var results = new List<int>();

            void Loop(FactorizedNumber number, int factorIndex, int currentResult)
            {
                int prime = number[factorIndex].Prime;

                for (int e = 0; e <= number[factorIndex].Exponent; e++)
                {
                    if (e > 0)
                        currentResult *= prime;

                    if (factorIndex == number.Count - 1)
                        results.Add(currentResult);
                    else
                        Loop(number, factorIndex + 1, currentResult);
                }
            }

            Loop(factorized, 0, 1);

            return results.Where(x => x != n);
        }
    }
}