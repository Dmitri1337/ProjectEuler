using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Largest prime factor
    /// </summary>
    public class Problem0003
    {
        public object GetResult()
        {
            const long number = 600851475143;

            int sqrNumber = (int) System.Math.Sqrt(number);

            for (int n = sqrNumber; n > 2; n--)
                if (Primes.IsPrime(n) && number % n == 0)
                    return n;

            return "unknown";
        }
    }
}