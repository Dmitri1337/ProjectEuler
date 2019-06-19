using System.Numerics;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     1000-digit Fibonacci number
    /// </summary>
    public class Problem0025
    {
        public object GetResult()
        {
            BigInteger thousandDigits = BigInteger.Pow(10, 999);

            BigInteger previousTerm = 0;
            BigInteger currentTerm = 1;
            int currentTermIndex = 1;

            while (currentTerm < thousandDigits)
            {
                BigInteger newTerm = previousTerm + currentTerm;
                previousTerm = currentTerm;
                currentTerm = newTerm;
                currentTermIndex++;
            }

            return currentTermIndex;
        }
    }
}