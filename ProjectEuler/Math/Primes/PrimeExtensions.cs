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

        public static FactorizedNumber Factorize(this int x)
        {
            if (x == 0)
                throw new ArgumentOutOfRangeException(nameof(x), "Cannot be zero.");

            return new FactorizedNumber(GetPrimeFactorsInternal(x));
        }

        private static IEnumerable<PrimeFactor> GetPrimeFactorsInternal(int x)
        {
            if (x < 0)
                x = -x;

            if (x.IsPrime())
            {
                yield return new PrimeFactor(x, 1);
                yield break;
            }

            int n = x;

            for (int prime = 2; n > 1 && prime <= x.GetIntegerSquareRoot(); prime++)
            {
                if (n.IsPrime())
                {
                    yield return new PrimeFactor(n, 1);
                    yield break;
                }

                if (!IsPrime(prime))
                    continue;

                int power = 0;
                int divisor = 1;
                int newDivisor = prime;

                while (n % newDivisor == 0)
                {
                    divisor = newDivisor;
                    power++;
                    newDivisor *= prime;
                }

                if (power > 0)
                {
                    n /= divisor;
                    yield return new PrimeFactor(prime, power);
                }
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

            int[] exponents = x.Factorize().Select(y => y.Exponent + 1).ToArray();
            
            int result = exponents.Aggregate(1, (a, b) => a * b);

            return result;
        }
    }
}