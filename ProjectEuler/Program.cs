using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Calculating result...");

            object result = new Problem0014().GetResult();

            Console.WriteLine(" done.");
            Console.WriteLine($"Result: {result}");

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}