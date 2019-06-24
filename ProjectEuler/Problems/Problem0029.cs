using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Distinct powers
    /// </summary>
    public class Problem0029
    {
        public object GetResult()
        {
            var numbers = new List<BigInteger>();

            for (int n = 2; n <= 100; n++)
            for (int p = 2; p <= 100; p++)
                numbers.Add(BigInteger.Pow(n, p));

            return numbers.Distinct().Count();
        }
    }
}