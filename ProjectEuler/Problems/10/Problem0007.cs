using ProjectEuler.Math.Primes;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     10001st prime
    /// </summary>
    public class Problem0007
    {
        public object GetResult()
        {
            int primeCount = 0;
            int currentNumber = 1;

            while (primeCount < 10001)
            {
                currentNumber++;

                if (currentNumber.IsPrime())
                    primeCount++;
            }

            return currentNumber;
        }
    }
}