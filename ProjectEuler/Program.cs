using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Calculating result...");

            object result = new Problem0004().GetResult();

            Console.WriteLine(" done.");
            Console.WriteLine($"Result: {result}");

            Console.ReadKey(true);
        }
    }
}