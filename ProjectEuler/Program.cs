using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Calculating result... ");

            object result = new Problem0026().GetResult();

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}