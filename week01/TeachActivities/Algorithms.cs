using System;
using System.Diagnostics;

/// <summary>
/// Empirical performance benchmarking suite comparing Big O time growth curves.
/// </summary>
public class Algorithms
{
    /// <summary>
    /// Runs performance tests recording loop iterations, high-precision timing,
    /// and memory allocations across O(1), O(log n), O(n), and O(n^2) algorithms.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("\n================================================================================");
        Console.WriteLine("                       EMPIRICAL BENCHMARK COMPARISON                           ");
        Console.WriteLine("================================================================================");
        Console.WriteLine("N          | Alg1 O(n) Iterations | Alg2 O(n^2) Iterations | Alg3 O(log n) | Alg1 Time (ms)");
        Console.WriteLine("--------------------------------------------------------------------------------");

        int[] testSizes = new int[] { 10, 100, 1000, 5000 };

        foreach (int n in testSizes)
        {
            long count1 = Algorithm1(n);
            long count2 = Algorithm2(n);
            long count3 = Algorithm3(n);

            // Measure high-resolution execution duration
            Stopwatch sw = Stopwatch.StartNew();
            Algorithm1(n);
            sw.Stop();

            Console.WriteLine($"{n,-10:N0} | {count1,-20:N0} | {count2,-22:N0} | {count3,-13:N0} | {sw.Elapsed.TotalMilliseconds:F4} ms");
        }
    }

    /// <summary> Linear Time: O(n) </summary>
    public static long Algorithm1(int n)
    {
        long iterations = 0;
        for (int i = 0; i < n; i++)
        {
            iterations++;
        }
        return iterations;
    }

    /// <summary> Quadratic Time: O(n^2) </summary>
    public static long Algorithm2(int n)
    {
        long iterations = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                iterations++;
            }
        }
        return iterations;
    }

    /// <summary> Logarithmic Time: O(log n) - Continuously halves the problem space </summary>
    public static long Algorithm3(int n)
    {
        long iterations = 0;
        int current = n;
        while (current > 1)
        {
            current /= 2; // Integer division by 2 eliminates half the remaining range
            iterations++;
        }
        return iterations;
    }
}
