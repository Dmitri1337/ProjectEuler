using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Reciprocal cycles
    /// </summary>
    public class Problem0026
    {
        public object GetResult()
        {
            return Enumerable.Range(1, 999)
                .Select(x => new { N = x, RepetendLength = GetReciprocalRepetendLength(x) })
                .OrderByDescending(x => x.RepetendLength)
                .First()
                .N;
        }

        private static int GetReciprocalRepetendLength(int n)
        {
            int gcd = XXMath.GreatestCommonDivisor(10, n);

            while (gcd != 1)
            {
                n /= gcd;
                gcd = XXMath.GreatestCommonDivisor(10, n);
            }

            if (n == 1)
                return 0;

            return XXMath.GetMultiplicativeOrder(10, n);
        }
    }
}