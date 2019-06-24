using ProjectEuler.Math.Primes;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Quadratic primes
    /// </summary>
    public class Problem0027
    {
        public object GetResult()
        {
            int bestA = 0;
            int bestB = 0;
            int maxLength = 0;

            for (int b = 1000; b >= 0; b--)
            {
                if (!b.IsPrime())
                    continue;

                for (int a = 0; a <= 999; a++)
                {
                    (int aa, int bb, int l) = GetMaxPrimeSequenceLength(a, b);

                    if (l <= maxLength)
                        continue;

                    maxLength = l;
                    bestA = aa;
                    bestB = bb;
                }
            }

            return bestA * bestB;
        }

        private static (int a, int b, int l) GetMaxPrimeSequenceLength(int a, int b)
        {
            (int a, int b, int l) r1 = GetPrimeSequenceLength(a, b);
            (int a, int b, int l) r2 = GetPrimeSequenceLength(-a, b);
            (int a, int b, int l) r3 = GetPrimeSequenceLength(a, -b);
            (int a, int b, int l) r4 = GetPrimeSequenceLength(-a, -b);

            return Max(Max(r1, r2), Max(r3, r4));
        }

        private static (int a, int b, int l) Max((int a, int b, int l) r1, (int a, int b, int l) r2)
        {
            return r1.l > r2.l ? r1 : r2;
        }

        private static (int a, int b, int l) GetPrimeSequenceLength(int a, int b)
        {
            int n = 0;
            while (GetQuadraticEquationValue(a, b, n).IsPrime())
                n++;

            return (a, b, n);
        }

        private static int GetQuadraticEquationValue(int a, int b, int n)
        {
            return n * n + a * n + b;
        }
    }
}