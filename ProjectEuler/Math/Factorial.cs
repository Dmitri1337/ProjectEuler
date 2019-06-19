using System.Numerics;

namespace ProjectEuler.Math
{
    public static class Factorial
    {
        public static BigInteger Get(int n)
        {
            BigInteger result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;

            return result;
        }
    }
}