using ProjectEuler.Math.Primes;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Highly divisible triangular number
    /// </summary>
    public class Problem0012
    {
        public object GetResult()
        {
            int n = 1;
            int numberOfFactors = 1;

            while (numberOfFactors < 500)
            {
                numberOfFactors = (n & 1) == 0
                    ? (n / 2).GetDivisorsCount() * (n + 1).GetDivisorsCount()
                    : n.GetDivisorsCount() * ((n + 1) / 2).GetDivisorsCount();

                n++;
            }

            return n * (n - 1) / 2;
        }
    }
}