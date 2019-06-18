using System;

namespace ProjectEuler.Math
{
    public static class Palindromes
    {
        public static int GetReversed(int number, int radix = 10)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Must be greater or equal to zero.");

            int reversedNumber = 0;

            while (number > 0)
            {
                reversedNumber *= radix;
                reversedNumber += number % radix;
                number /= radix;
            }

            return reversedNumber;
        }

        public static bool IsPalindrome(int number, int radix = 10)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Must be greater or equal to zero.");

            if (radix < 2)
                throw new ArgumentOutOfRangeException(nameof(radix), "Must be greater than one.");

            return number == GetReversed(number, radix);
        }
    }
}