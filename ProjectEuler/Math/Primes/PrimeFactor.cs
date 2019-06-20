using System;

namespace ProjectEuler.Math.Primes
{
    public struct PrimeFactor
    {
        public PrimeFactor(int prime, int exponent)
        {
            if (!prime.IsPrime())
                throw new ArgumentOutOfRangeException(nameof(prime), "Must be a prime number.");

            if (exponent < 1)
                throw new ArgumentOutOfRangeException(nameof(exponent), "Must greater than zero.");

            Prime = prime;
            Exponent = exponent;
        }

        public int Prime { get; }
        public int Exponent { get; }

        public long ToLong()
        {
            return (long)System.Math.Pow(Prime, Exponent);
        }
    }
}