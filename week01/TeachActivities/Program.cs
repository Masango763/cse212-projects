using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("========================================================================");
        Console.WriteLine("          CSE 212: ENHANCED DYNAMIC ARRAYS & PERFORMANCE ANALYSIS       ");
        Console.WriteLine("========================================================================");

        // ---------------------------------------------------------------------
        // PART 1: Divisors Optimization Comparison: O(n) vs O(sqrt(n))
        // ---------------------------------------------------------------------
        Console.WriteLine("\n--- Part 1: Divisor Calculation & Algorithmic Optimization ---");
        int testNumber = 100_000;

        Stopwatch sw = Stopwatch.StartNew();
        List<int> stdDivisors = Divisors.FindDivisorsStandard(testNumber);
        sw.Stop();
        double stdTime = sw.Elapsed.TotalMilliseconds;

        sw.Restart();
        List<int> optDivisors = Divisors.FindDivisorsOptimized(testNumber);
        sw.Stop();
        double optTime = sw.Elapsed.TotalMilliseconds;

        Console.WriteLine($"Number: {testNumber:N0}");
        Console.WriteLine($"Standard O(n) Method     : {stdTime:F4} ms | Found {stdDivisors.Count} divisors");
        Console.WriteLine($"Optimized O(sqrt n) Method: {optTime:F4} ms | Found {optDivisors.Count} divisors");
        Console.WriteLine($"Speedup factor           : {(stdTime > 0 ? (stdTime / Math.Max(optTime, 0.0001)): 1):F1}x faster");

        // ---------------------------------------------------------------------
        // PART 2: Generic Array Selector with Type Reusability
        // ---------------------------------------------------------------------
        Console.WriteLine("\n--- Part 2: Generic Array Selector (int & string support) ---");
        
        // Integer Example
        int[] arr1 = { 1, 2, 3, 4 };
        int[] arr2 = { 10, 20, 30, 40 };
        int[] selectInt = { 1, 1, 2, 2, 1, 1, 2, 2 };
        int[] mergedInts = ArraySelector.ListSelector(arr1, arr2, selectInt);
        Console.WriteLine($"Merged Integers: [{string.Join(", ", mergedInts)}]");

        // String Generic Example
        string[] strArr1 = { "Apple", "Banana" };
        string[] strArr2 = { "Cherry", "Date" };
        int[] selectStr = { 1, 2, 1, 2 };
        string[] mergedStrings = ArraySelector.ListSelector(strArr1, strArr2, selectStr);
        Console.WriteLine($"Merged Strings : [{string.Join("\", \"", mergedStrings)}]");

        // ---------------------------------------------------------------------
        // PART 3: Big O Empirical Benchmark Analysis
        // ---------------------------------------------------------------------
        Algorithms.Run();
    }
}
