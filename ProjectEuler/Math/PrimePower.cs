using System;

namespace ProjectEuler.Math
{
    public class PrimePower
    {
        public PrimePower(int prime, int power)
        {
            if (!Primes.IsPrime(prime))
                throw new ArgumentOutOfRangeException(nameof(prime), "Must be a prime number.");

            if (power < 1)
                throw new ArgumentOutOfRangeException(nameof(power), "Must greater than zero.");

            Prime = prime;
            Power = power;
        }

        public int Prime { get; }
        public int Power { get; }

        public long ToLong()
        {
            return (long) System.Math.Pow(Prime, Power);
        }
    }
}