using System;
using System.Linq;
using System.Numerics;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Math
{
    public static partial class XMath
    {
        /// <summary>
        ///     Calculates the order of <paramref name="m" /> modulo <paramref name="n" />. The order of an integer
        ///     <paramref name="m" /> modulo <paramref name="n" /> is defined to be the smallest positive integer power r
        ///     such that m^r % n == 1.
        /// </summary>
        public static int GetMultiplicativeOrder(int m, int n)
        {
            int gcd = GreatestCommonDivisor(m, n);
            if (gcd != 1)
                throw new ArithmeticException($"GCD({nameof(m)}, {nameof(n)}) must be 1, found {gcd}.");

            int totient = n.GetEulersTotient();
            int[] divisors = totient.GetProperDivisors().ToArray();
            //int[] divisors2 = PrimeExtensions.GetProperDivisors(totient).OrderBy(x => x).ToArray();

            foreach (int divisor in divisors)
                if (BigInteger.ModPow(m, divisor, n) == 1)
                    return divisor;

            return totient;
        }
    }
}