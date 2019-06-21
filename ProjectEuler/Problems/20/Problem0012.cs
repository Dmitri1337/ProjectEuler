using System.Linq;
using ProjectEuler.Benchmarks;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Highly divisible triangular number
    /// </summary>
    public class Problem0012
    {
        public object GetResult()
        {
            Benchmark.Run(GetResult1, 2);
            Benchmark.Run(GetResult2, 2);
            Benchmark.Run(GetResult3, 2);
            Benchmark.Run(GetResult4, 2);

            return null;
        }

        public object GetResult1()
        {
            int addend = 3;
            int number = 3;
            int numberOfFactors = 2;

            while (numberOfFactors < 500)
            {
                number += addend;
                addend++;

                numberOfFactors = number.GetPrimeFactors()
                    .Select(x => x.Exponent + 1)
                    .Aggregate(1, (a, b) => a * b);
            }

            return number;
        }

        public object GetResult2()
        {
            int addend = 3;
            int number = 3;
            int numberOfFactors = 2;

            while (numberOfFactors < 500)
            {
                number += addend;
                addend++;

                numberOfFactors = number.GetProperDivisors().Count() + 1;
            }

            return number;
        }

        public object GetResult3()
        {
            int addend = 3;
            int number = 3;
            int numberOfFactors = 2;

            while (numberOfFactors < 500)
            {
                number += addend;
                addend++;

                numberOfFactors = number.GetDivisorsCount();
            }

            return number;
        }

        public object GetResult4()
        {
            int n = 1;
            int numberOfFactors = 1;

            while (numberOfFactors < 500)
            {
                numberOfFactors = (n & 1) == 0
                    ? (n / 2).GetDivisorsCount() * (n + 1).GetDivisorsCount()
                    : n.GetDivisorsCount() * ((n + 1) / 2).GetDivisorsCount();

                n++;
            }

            return n * (n - 1) / 2;
        }
    }
}