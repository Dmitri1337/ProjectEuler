using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using ProjectEuler.Benchmarks;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Pandigital products
    /// </summary>
    public class Problem0032
    {
        public object GetResult()
        {
            Benchmark.Run(GetResult2, 1);
            return 0;
        }

        public object GetResult1()
        {
            var results = new List<int>();
            Span<bool> digitsUsed = stackalloc bool[10];
            Span<bool> digitsUsedCopy = stackalloc bool[10];

            for (int d1 = 0; d1 <= 9; d1++)
            {
                digitsUsed[d1] = true;
                for (int d2 = 1; d2 <= 9; d2++)
                {
                    if (digitsUsed[d2])
                        continue;

                    digitsUsed[d2] = true;

                    int multiplicand = d1 * 10 + d2;

                    for (int d3 = 0; d3 <= 9; d3++)
                    {
                        if (d3 > 0 && digitsUsed[d3])
                            continue;

                        digitsUsed[d3] = true;

                        for (int d4 = 1; d4 <= 9; d4++)
                        {
                            if (digitsUsed[d4])
                                continue;

                            digitsUsed[d4] = true;

                            for (int d5 = 1; d5 <= 9; d5++)
                            {
                                if (digitsUsed[d5])
                                    continue;

                                digitsUsed[d5] = true;

                                for (int d6 = 1; d6 <= 9; d6++)
                                {
                                    if (digitsUsed[d6])
                                        continue;

                                    digitsUsed[d6] = true;

                                    int multiplier = d3 * 1000 + d4 * 100 + d5 * 10 + d6;
                                    int product = multiplicand * multiplier;

                                    bool isPandigital = true;
                                    digitsUsed.TryCopyTo(digitsUsedCopy);

                                    int productCopy = product;
                                    while (productCopy > 0)
                                    {
                                        int dm = productCopy % 10;
                                        if (dm == 0 || digitsUsedCopy[dm])
                                        {
                                            isPandigital = false;
                                            break;
                                        }

                                        digitsUsedCopy[dm] = true;
                                        productCopy /= 10;
                                    }

                                    if (isPandigital)
                                    {
                                        int digitsUsedCount = 0;
                                        for (int g = 1; g < digitsUsedCopy.Length; g++)
                                            if (digitsUsedCopy[g])
                                                digitsUsedCount++;

                                        if (digitsUsedCount >= 9)
                                            results.Add(product);
                                    }
                                        

                                    digitsUsed[d6] = false;
                                }

                                digitsUsed[d5] = false;
                            }

                            digitsUsed[d4] = false;
                        }

                        digitsUsed[d3] = false;
                    }

                    digitsUsed[d2] = false;
                }

                digitsUsed[d1] = false;
            }

            return results.Distinct().Sum();
        }

        public object GetResult2()
        {
            var results = new List<int>();
            var digitsInUse = new bool[10];

            foreach (int multiplicand in GetMultiplicands(digitsInUse))
            foreach (int multiplier in GetMultipliers(digitsInUse))
            {
                int product = multiplicand * multiplier;

                if (IsPandigitalProduct(digitsInUse, product))
                        results.Add(product);
            }

            return results.Distinct().Sum();
        }

        private static IEnumerable<int> GetMultiplicands(bool[] digitsInUse)
        {
            foreach (int d1 in GetUnusedDigits(digitsInUse, true))
            foreach (int d2 in GetUnusedDigits(digitsInUse))
                yield return d1 * 10 + d2;
        }

        private static IEnumerable<int> GetMultipliers(bool[] digitsInUse)
        {
            foreach (int d1 in GetUnusedDigits(digitsInUse, true))
            foreach (int d2 in GetUnusedDigits(digitsInUse))
            foreach (int d3 in GetUnusedDigits(digitsInUse))
            foreach (int d4 in GetUnusedDigits(digitsInUse))
                yield return d1 * 1000 + d2 * 100 + d3 * 10 + d4;
        }

        private static IEnumerable<int> GetUnusedDigits(bool[] digits, bool includeZero = false)
        {
            return new UnusedDigits(digits, includeZero);
        }


        private static bool IsPandigitalProduct(bool[] digitsInUse, int product)
        {
            int totalDigitCount = digitsInUse.Skip(1).Count(x => x);

            Span<bool> digitsInUseWithProduct = stackalloc bool[digitsInUse.Length];
            digitsInUse.CopyTo(digitsInUseWithProduct);

            while (product > 0)
            {
                int productDigit = product % 10;
                if (productDigit == 0 || digitsInUseWithProduct[productDigit])
                    return false;

                digitsInUseWithProduct[productDigit] = true;
                product /= 10;
                totalDigitCount++;
            }

            return totalDigitCount == 9;
        }

        private class UnusedDigits : IEnumerable<int>
        {
            private readonly bool[] _digits;
            private readonly bool _includeZero;

            public UnusedDigits(bool[] digits, bool includeZero)
            {
                _digits = digits;
                _includeZero = includeZero;
            }

            public IEnumerator<int> GetEnumerator()
            {
                return new UnusedDigitsEnumerator(_digits, _includeZero);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class UnusedDigitsEnumerator : IEnumerator<int>
        {
            private readonly bool[] _digits;
            private readonly bool _includeZero;
            private int _lastDigit;

            public UnusedDigitsEnumerator(bool[] digits, bool includeZero)
            {
                _digits = digits;
                _includeZero = includeZero;
            }

            public bool MoveNext()
            {
                _digits[_lastDigit] = false;

                int nextDigit = GetNextDigit();
                if (nextDigit == -1)
                    return false;

                Current = nextDigit;
                _lastDigit = Current;
                _digits[Current] = true;

                return true;
            }

            private int GetNextDigit()
            {
                if (Current == -1 && _includeZero)
                    return 0;

                int d = Current;
                if (d == -1)
                    d = 1;

                while (true)
                {
                    d++;

                    if (d == 10)
                        return -1;

                    if (!_digits[d])
                        return d;
                }
            }

            public void Reset()
            {
                Current = -1;
                _lastDigit = 0;
            }

            public int Current { get; private set; } = -1;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}