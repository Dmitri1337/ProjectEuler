﻿using System;
using ProjectEuler.Problems;

namespace ProjectEuler
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Calculating result... ");

            object result = new Problem0034().GetResult();

            Console.WriteLine(result);
            Console.WriteLine();
        }
    }
}