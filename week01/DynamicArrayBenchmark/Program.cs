using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int count = 100_000;
        Console.WriteLine($"=== Dynamic Array Performance ({count:N0} Items) ===\n");

        // 1. Measure Append - O(1) Amortized
        var sw = Stopwatch.StartNew();
        var numbers = new List<int>();
        for (int i = 0; i < count; i++)
        {
            numbers.Add(i);
        }
        sw.Stop();
        Console.WriteLine($"1. Append {count:N0} items to end: {sw.ElapsedMilliseconds} ms");

        // 2. Measure Insert at Start - O(n) due to element shifting
        int insertCount = 20_000;
        sw.Restart();
        var frontList = new List<int>();
        for (int i = 0; i < insertCount; i++)
        {
            frontList.Insert(0, i);
        }
        sw.Stop();
        Console.WriteLine($"2. Insert {insertCount:N0} items at index 0: {sw.ElapsedMilliseconds} ms");

        // 3. Measure Lookup - O(1) Constant Time
        sw.Restart();
        int item = numbers[50_000];
        sw.Stop();
        Console.WriteLine($"3. Lookup index 50,000: {sw.Elapsed.TotalMicroseconds:F2} μs");
    }
}
