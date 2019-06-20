using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Summation of primes
    /// </summary>
    public class Problem0010
    {
        public object GetResult()
        {
            // the result can also be calculated using Wolfram Alpha:
            // https://www.wolframalpha.com/input/?i=sum(primes+%3C%3D2000000)

            return Enumerable.Range(1, 2000000)
                .Where(x => x.IsPrime())
                .Select(x => (long)x)
                .Sum();
        }
    }
}