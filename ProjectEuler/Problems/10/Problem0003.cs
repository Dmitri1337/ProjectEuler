using ProjectEuler.Math;
using ProjectEuler.Math.Primes;

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
            // int sqrNumber = (int)System.Math.Sqrt(number);
            int sqrNumber = number.GetIntegerSquareRoot();

            for (int n = sqrNumber; n > 2; n--)
                if (number % n == 0 && n.IsPrime())
                    return n;

            return "unknown";
        }
    }
}