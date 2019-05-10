using System;

namespace ProjectEuler.Math
{
    public static class Palindromes
    {
        public static int GetReversed(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Must be greater or equal to zero.");

            int reversedNumber = 0;

            while (number > 0)
            {
                reversedNumber *= 10;
                reversedNumber += number % 10;
                number /= 10;
            }

            return reversedNumber;
        }

        public static bool IsPalindrome(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "Must be greater or equal to zero.");
            
            return number == GetReversed(number);
        }
    }
}