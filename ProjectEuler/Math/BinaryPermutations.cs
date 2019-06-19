using System.Numerics;

namespace ProjectEuler.Math
{
    public static class BinaryPermutations
    {
        public static BigInteger GetPermutationsCount(int bitCount, int onesCount)
        {
            int zeroesCount = bitCount - onesCount;
            return Factorial.Get(bitCount) / (Factorial.Get(onesCount) * Factorial.Get(zeroesCount));
        }
    }
}