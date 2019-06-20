using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEuler.Math
{
    public static class Factorial
    {
        public static BigInteger GetFactorial(this int x)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException(nameof(x), "Must be greater or equal to zero.");

            BigInteger result = 1;
            for (int i = 1; i <= x; i++)
                result *= i;

            return result;
        }

        public static IReadOnlyList<int> GetFactoradicDigits(this int x)
        {
            if (x < 0)
                throw new ArgumentOutOfRangeException(nameof(x), "Must be greater than or equal to zero.");

            var digits = new List<int> { 0 };
            int divider = 2;

            while (x > 0)
            {
                digits.Add(x % divider);
                x /= divider;
                divider++;
            }

            digits.Reverse();

            return digits.AsReadOnly();
        }
    }
}