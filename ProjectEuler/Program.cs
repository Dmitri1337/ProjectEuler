using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Calculating result...");

            object result = new Problem0020().GetResult();

            Console.WriteLine($"Result: {result}");
            Console.WriteLine();
        }
    }
}