using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("==========================================");
        Console.WriteLine("    CSE 212 WEEK 01 TEACH ACTIVITIES");
        Console.WriteLine("==========================================");

        // Part 1: Divisors
        Console.WriteLine("\n--- Part 1: Find Divisors ---");
        int num = 12;
        Console.WriteLine($"Divisors of {num}: {{{string.Join(", ", Divisors.FindDivisors(num))}}}");

        int primeNum = 17;
        Console.WriteLine($"Divisors of {primeNum}: {{{string.Join(", ", Divisors.FindDivisors(primeNum))}}}");

        // Part 2: ArraySelector
        Console.WriteLine("\n--- Part 2: Array Selector ---");
        int[] arr1 = { 1, 2, 3, 4 };
        int[] arr2 = { 10, 20, 30, 40 };
        int[] select = { 1, 1, 2, 2, 1, 1, 2, 2 };
        int[] result = ArraySelector.ListSelector(arr1, arr2, select);
        Console.WriteLine($"Combined Array: {{{string.Join(", ", result)}}}");

        // Part 3: Algorithms
        Console.WriteLine("\n--- Part 3: Algorithm Performance ---");
        Algorithms.Run();
    }
}
