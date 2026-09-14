namespace week03.teach;

public static class DisplaySums
{
    /// <summary>
    /// Displays all pairs of numbers in a list that sum up to 10 using a set.
    /// Assumes no duplicates in the input list.
    /// </summary>
    public static void DisplaySumPairs(int[] numbers)
    {
        var seen = new HashSet<int>();

        foreach (var x in numbers)
        {
            int complement = 10 - x;
            if (seen.Contains(complement))
            {
                Console.WriteLine($"{complement} + {x} = 10");
            }
            seen.Add(x);
        }
    }
}
