using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Even Fibonacci numbers
    /// </summary>
    public class Problem0002
    {
        public object GetResult()
        {
            const int max = 4000000;

            return GetFibonacciNumbers()
                .TakeWhile(x => x < max)
                .Where(x => x % 2 == 0)
                .Sum();
        }

        private static IEnumerable<int> GetFibonacciNumbers()
        {
            int previous = 0;
            int current = 1;

            while (true)
            {
                yield return current;

                int newCurrent = previous + current;
                previous = current;
                current = newCurrent;
            }

            // ReSharper disable once IteratorNeverReturns
        }
    }
}