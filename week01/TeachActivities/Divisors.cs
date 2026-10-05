using System;
using System.Collections.Generic;

/// <summary>
/// Provides utility methods for calculating mathematical divisors using dynamic arrays.
/// </summary>
public class Divisors
{
    /// <summary>
    /// Standard implementation: Iterates linearly up to (number - 1).
    /// Time Complexity: O(n) - scales linearly with input magnitude.
    /// Space Complexity: O(d) - where d is the count of valid divisors stored in the List.
    /// </summary>
    /// <param name="number">The integer to find divisors for.</param>
    /// <returns>A List of integers containing all proper divisors.</returns>
    public static List<int> FindDivisorsStandard(int number)
    {
        if (number <= 1) return new List<int>();

        List<int> divisors = new List<int>();

        // Check every integer from 1 up to (number - 1)
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
            {
                divisors.Add(i); // Appends in O(1) amortized time
            }
        }

        return divisors;
    }

    /// <summary>
    /// Advanced Implementation: Iterates only up to sqrt(number).
    /// Finds paired divisors (i and number / i) simultaneously.
    /// Time Complexity: O(sqrt(n)) - drastically faster for large inputs.
    /// Space Complexity: O(d) - stores matching factors in a dynamic List.
    /// </summary>
    public static List<int> FindDivisorsOptimized(int number)
    {
        if (number <= 1) return new List<int>();

        List<int> divisors = new List<int>();
        int limit = (int)Math.Sqrt(number);

        for (int i = 1; i <= limit; i++)
        {
            if (number % i == 0)
            {
                divisors.Add(i);

                // Add corresponding pair factor if it's distinct and not the number itself
                int complement = number / i;
                if (complement != i && complement != number)
                {
                    divisors.Add(complement);
                }
            }
        }

        // Sort divisors sequentially (O(d log d) where d is tiny relative to n)
        divisors.Sort();
        return divisors;
    }
}
