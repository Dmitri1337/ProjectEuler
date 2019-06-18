using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectEuler.Math
{
    public static class Primes
    {
        private const int MaxPrime = 2000000;
        private const long MaxFactorize = (long)MaxPrime * MaxPrime;

        private static readonly BitArray Sieve = GetSieve();

        public static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            if (number > MaxPrime)
                throw new ArgumentOutOfRangeException(nameof(number), $"Cannot be greater than {MaxPrime}.");

            return Sieve[number];
        }

        private static BitArray GetSieve()
        {
            var sieve = new BitArray(MaxPrime + 1, true) { [0] = false, [1] = false };

            for (int i = 2; i < sieve.Count; i++)
                if (sieve[i])
                    for (int g = i + i; g < sieve.Count; g += i)
                        sieve[g] = false;

            return sieve;
        }

        public static IReadOnlyCollection<PrimePower> Factorize(int number)
        {
            if (number < 2)
                throw new ArgumentOutOfRangeException(nameof(number), "Cannot be less than 2.");

            var result = new List<PrimePower>();
            int n = number;

            for (int prime = 2; prime <= MaxPrime && n > 1; prime++)
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
                    result.Add(new PrimePower(prime, power));
            }

            return result.AsReadOnly();
        }
    }
}