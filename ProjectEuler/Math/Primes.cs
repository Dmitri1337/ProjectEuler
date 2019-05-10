using System;
using System.Collections;

namespace ProjectEuler.Math
{
    public static class Primes
    {
        private const int MaxPrime = 1000000;

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
    }
}