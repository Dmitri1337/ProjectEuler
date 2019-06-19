using System.Linq;
using ProjectEuler.Math;

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
                .SelectMany(Primes.Factorize)
                .GroupBy(x => x.Prime)
                .Select(x => x.OrderByDescending(y => y.Power).First())
                .Select(x => x.ToLong())
                .Aggregate((long) 1, (x, y) => x * y);
        }
    }
}