﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Pandigital products
    /// </summary>
    public class Problem0032
    {
        public object GetResult()
        {
            var results = new List<int>();
            Span<bool> digits = stackalloc bool[10];
            Span<bool> digitsWithProduct = stackalloc bool[10];

            for (int d1 = 0; d1 <= 9; d1++)
            {
                digits[d1] = true;
                for (int d2 = 2; d2 <= 9; d2++)
                {
                    if (digits[d2])
                        continue;

                    digits[d2] = true;

                    int multiplicand = d1 * 10 + d2;

                    const int maxProduct = 9876;

                    int maxMultiplier = maxProduct / multiplicand;

                    for (int d3 = 0; d3 <= 9; d3++)
                    {
                        if (d3 > 0 && digits[d3])
                            continue;

                        int d3Multiplier = d3 * 1000;

                        if (d3Multiplier > maxMultiplier)
                            break;

                        digits[d3] = true;

                        for (int d4 = 1; d4 <= 9; d4++)
                        {
                            if (digits[d4])
                                continue;

                            int d4Multiplier = d3Multiplier + d4 * 100;
                            if (d4Multiplier > maxMultiplier)
                                break;

                            digits[d4] = true;

                            for (int d5 = 1; d5 <= 9; d5++)
                            {
                                if (digits[d5])
                                    continue;

                                int d5Multiplier = d4Multiplier + d5 * 10;
                                if (d5Multiplier > maxMultiplier)
                                    break;

                                digits[d5] = true;

                                for (int d6 = 2; d6 <= 9; d6++)
                                {
                                    if (digits[d6])
                                        continue;

                                    int d6Multiplier = d5Multiplier + d6;
                                    if (d6Multiplier > maxMultiplier)
                                        break;

                                    digits[d6] = true;

                                    int multiplier = d3 * 1000 + d4 * 100 + d5 * 10 + d6;
                                    int product = multiplicand * multiplier;

                                    bool isPandigital = true;
                                    digits.TryCopyTo(digitsWithProduct);

                                    int productCopy = product;
                                    while (productCopy > 0)
                                    {
                                        int dm = productCopy % 10;
                                        if (dm == 0 || digitsWithProduct[dm])
                                        {
                                            isPandigital = false;
                                            break;
                                        }

                                        digitsWithProduct[dm] = true;
                                        productCopy /= 10;
                                    }

                                    if (isPandigital)
                                    {
                                        int digitsUsedCount = 0;
                                        for (int g = 1; g < digitsWithProduct.Length; g++)
                                            if (digitsWithProduct[g])
                                                digitsUsedCount++;

                                        if (digitsUsedCount >= 9)
                                            results.Add(product);
                                    }

                                    digits[d6] = false;
                                }

                                digits[d5] = false;
                            }

                            digits[d4] = false;
                        }

                        digits[d3] = false;
                    }

                    digits[d2] = false;
                }

                digits[d1] = false;
            }

            return results.Distinct().Sum();
        }
    }
}