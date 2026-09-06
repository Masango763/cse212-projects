using System;

public class Algorithms
{
    public static void Run()
    {
        Console.WriteLine("\nWork (Iteration Count) Comparison Across Input Sizes:");
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine("N\t| Alg1 O(n)\t| Alg2 O(n^2)\t| Alg3 O(log n)");
        Console.WriteLine("---------------------------------------------------------");

        int[] testSizes = new int[] { 10, 100, 1000, 5000 };

        foreach (int n in testSizes)
        {
            long count1 = Algorithm1(n);
            long count2 = Algorithm2(n);
            long count3 = Algorithm3(n);

            Console.WriteLine($"{n}\t| {count1:N0}\t\t| {count2:N0}\t| {count3:N0}");
        }
    }

    public static long Algorithm1(int n)
    {
        long count = 0;
        for (int i = 0; i < n; i++) count++;
        return count;
    }

    public static long Algorithm2(int n)
    {
        long count = 0;
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++) count++;
        return count;
    }

    public static long Algorithm3(int n)
    {
        long count = 0;
        int curr = n;
        while (curr > 1)
        {
            curr /= 2;
            count++;
        }
        return count;
    }
}
