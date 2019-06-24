using System;

namespace ProjectEuler.Math.Primes
{
    public struct PrimeFactor : IEquatable<PrimeFactor>
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

        public long ToInt64()
        {
            return (long)System.Math.Pow(Prime, Exponent);
        }

        public int ToInt32()
        {
            return (int)System.Math.Pow(Prime, Exponent);
        }

        public bool Equals(PrimeFactor other)
        {
            return Prime == other.Prime && Exponent == other.Exponent;
        }

        public override bool Equals(object obj)
        {
            return obj is PrimeFactor other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Prime * 397) ^ Exponent;
            }
        }

        public static bool operator ==(PrimeFactor a, PrimeFactor b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(PrimeFactor a, PrimeFactor b)
        {
            return !a.Equals(b);
        }
    }
}