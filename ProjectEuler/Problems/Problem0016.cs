using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Power digit sum
    /// </summary>
    public class Problem0016
    {
        public object GetResult()
        {
            return BigInteger
                .Pow(2, 1000)
                .ToString()
                .Select(x => x - 48)
                .Sum();
        }
    }
}