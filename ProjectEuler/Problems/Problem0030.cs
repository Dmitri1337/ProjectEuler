using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Digit fifth powers
    /// </summary>
    public class Problem0030
    {
        public object GetResult()
        {
            const int maxNumber = 9 * 9 * 9 * 9 * 9 * 5;

            var results = new List<int>();
            int[] fifthPowers = Enumerable.Range(0, 10).Select(x => x * x * x * x * x).ToArray();

            for (int digit1 = 0; digit1 <= 9; digit1++)
            {
                int number1 = digit1 * 100000;
                if (number1 > maxNumber)
                    break;

                int sum1 = fifthPowers[digit1];

                for (int digit2 = 0; digit2 <= 9; digit2++)
                {
                    int number2 = number1 + digit2 * 10000;
                    if (number2 > maxNumber)
                        break;

                    int sum2 = sum1 + fifthPowers[digit2];

                    for (int digit3 = 0; digit3 <= 9; digit3++)
                    {
                        int number3 = number2 + digit3 * 1000;
                        int sum3 = sum2 + fifthPowers[digit3];

                        for (int digit4 = 0; digit4 <= 9; digit4++)
                        {
                            int number4 = number3 + digit4 * 100;
                            int sum4 = sum3 + fifthPowers[digit4];

                            for (int digit5 = 0; digit5 <= 9; digit5++)
                            {
                                int number5 = number4 + digit5 * 10;
                                int sum5 = sum4 + fifthPowers[digit5];

                                for (int digit6 = 0; digit6 <= 9; digit6++)
                                {
                                    int number6 = number5 + digit6;
                                    int sum6 = sum5 + fifthPowers[digit6];

                                    if (number6 == sum6)
                                        results.Add(number6);
                                }
                            }
                        }
                    }
                }
            }

            return results.Where(x => x > 1).Sum();
        }
    }
}