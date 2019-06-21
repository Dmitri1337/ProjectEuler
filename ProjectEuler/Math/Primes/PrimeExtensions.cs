using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Math.Primes
{
    public static class PrimeExtensions
    {
        private const int EratosthenesSieveCapacity = 8 * 1024 * 1024; // ~ 1MB

        private static readonly EratosthenesSieve Sieve = new EratosthenesSieve(EratosthenesSieveCapacity);

        public static bool IsPrime(this int x)
        {
            return Sieve.IsPrime(x);
        }

        public static IEnumerable<PrimeFactor> GetPrimeFactors(this int x)
        {
            if (x == 0)
                throw new ArgumentOutOfRangeException(nameof(x), "Cannot be zero.");

            return GetPrimeFactorsInternal(x);
        }

        private static IEnumerable<PrimeFactor> GetPrimeFactorsInternal(int x)
        {
            if (x < 0)
                x = -x;

            int n = x;

            for (int prime = 2; n > 1; prime++)
            {
                if (!IsPrime(prime))
                    continue;

                int power = 0;

                while (n % prime == 0)
                {
                    power++;
                    n /= prime;
                }

                if (power > 0)
                    yield return new PrimeFactor(prime, power);
            }
        }

        public static IEnumerable<int> GetProperDivisors(this int x)
        {
            if (x < 0)
                x = -x;

            if (x == 0)
                yield break;

            yield return 1;

            if (x == 1)
                yield break;

            int sqrt = x.GetIntegerSquareRoot() + 1;

            for (int i = 2; i < sqrt; i++)
            {
                if (x % i != 0)
                    continue;

                int v = x / i;
                yield return v;

                if (v != i)
                    yield return i;
            }
        }

        public static int GetDivisorsCount(this int x)
        {
            if (x < 0)
                x = -x;

            if (x == 0)
                return 0;

            if (x == 1)
                return 1;

            PrimeFactor[] primeFactors = x.GetPrimeFactors().ToArray();
            int[] exponents = primeFactors.Select(y => y.Exponent + 1).ToArray();

            int result = exponents.Aggregate(1, (a, b) => a * b);

            return result;
        }

        public static int GetProperDivisorsCount(this int x)
        {
            return GetDivisorsCount(x) - 1;
        }
    }
}