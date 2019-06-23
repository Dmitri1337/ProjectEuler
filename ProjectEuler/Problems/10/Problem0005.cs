using System.Linq;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Smallest multiple
    /// </summary>
    public class Problem0005
    {
        public object GetResult()
        {
            const int max = 20;

            return Enumerable.Range(2, max - 1)
                .SelectMany(x => x.Factorize())
                .GroupBy(x => x.Prime)
                .Select(x => x.OrderByDescending(y => y.Exponent).First())
                .Select(x => x.ToLong())
                .Aggregate((long)1, (x, y) => x * y);
        }
    }
}