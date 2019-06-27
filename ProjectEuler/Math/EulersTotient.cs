using System.Numerics;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Math
{
    public static partial class XXMath
    {
        public static int GetEulersTotient(this int n)
        {
            FactorizedNumber factorizedNumber = n.Factorize();

            BigInteger result = 1;
            foreach (PrimeFactor primeFactor in factorizedNumber)
            {
                BigInteger p2 = BigInteger.Pow(primeFactor.Prime, primeFactor.Exponent - 1);
                BigInteger p1 = p2 * primeFactor.Prime;

                result *= p1 - p2;
            }

            return (int)result;
        }
    }
}