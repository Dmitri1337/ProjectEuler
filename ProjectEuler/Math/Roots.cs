using System;

namespace ProjectEuler.Math
{
    public static class Roots
    {
        public static int GetIntegerSquareRoot(this int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "Must be greater than or equal to zero.");

            // Find greatest shift.
            int shift = 2;
            int nShifted = n >> shift;

            // We check for nShifted being n, since some implementations
            // perform shift operations modulo the word size.
            while (nShifted != 0 && nShifted != n)
            {
                shift += 2;
                nShifted = n >> shift;
            }

            shift -= 2;

            // Find digits of result.
            int result = 0;
            while (shift >= 0)
            {
                result <<= 1;
                int candidateResult = result + 1;
                if (candidateResult * candidateResult <= n >> shift)
                    result = candidateResult;

                shift -= 2;
            }

            return result;
        }

        public static int GetIntegerSquareRoot(this long n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException(nameof(n), "Must be greater than or equal to zero.");

            // Find greatest shift.
            int shift = 2;
            long nShifted = n >> shift;

            // We check for nShifted being n, since some implementations
            // perform shift operations modulo the word size.
            while (nShifted != 0 && nShifted != n)
            {
                shift += 2;
                nShifted = n >> shift;
            }

            shift -= 2;

            // Find digits of result.
            long result = 0;
            while (shift >= 0)
            {
                result <<= 1;
                long candidateResult = result + 1;
                if (candidateResult * candidateResult <= n >> shift)
                    result = candidateResult;

                shift -= 2;
            }

            return (int)result;
        }
    }
}