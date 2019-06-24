using System.Collections.Generic;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Lexicographic permutations
    /// </summary>
    public class Problem0024
    {
        public object GetResult()
        {
            const int permutationIndex = 1000000 - 1;
            IReadOnlyList<int> factoradicDigits = permutationIndex.GetFactoradicDigits();

            var digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var resultDigits = new List<int>();

            foreach (int factoradicDigit in factoradicDigits)
            {
                resultDigits.Add(digits[factoradicDigit]);
                digits.RemoveAt(factoradicDigit);
            }

            long result = 0;
            foreach (int digit in resultDigits)
                result = result * 10 + digit;

            return result;
        }
    }
}