using System.Collections.Generic;

public class Divisors
{
    public static List<int> FindDivisors(int number)
    {
        List<int> results = new List<int>();
        for (int i = 1; i < number; i++)
        {
            if (number % i == 0)
            {
                results.Add(i);
            }
        }
        return results;
    }
}
