using System;
using System.Diagnostics;

namespace ProjectEuler.Benchmarks
{
    public static class Benchmark
    {
        public static void Run(Func<object> action, int iterationCount)
        {
            Console.WriteLine();

            Stopwatch timer = Stopwatch.StartNew();
            object result = null;
            for (int i = 0; i < iterationCount; i++)
                result =action();

            timer.Stop();
            Console.WriteLine($"{result} - {timer.Elapsed}");
        }
    }
}