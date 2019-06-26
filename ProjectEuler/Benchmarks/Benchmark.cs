using System;
using System.Diagnostics;

namespace ProjectEuler.Benchmarks
{
    public static class Benchmark
    {
        public static object Run(Func<object> action, int iterationCount)
        {
            Console.WriteLine();

            Stopwatch timer = Stopwatch.StartNew();
            object result = null;
            for (int i = 0; i < iterationCount; i++)
                result = action();

            timer.Stop();
            Console.WriteLine($"{result} - {timer.Elapsed}");
            
            return null;
        }

        public static object Run(Func<object> action1, Func<object> action2, int iterationCount)
        {
            Run(action1, iterationCount);
            Run(action2, iterationCount);

            return null;
        }
    }
}