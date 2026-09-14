namespace week03.learn;

public static class DuplicateCounter
{
    public static int CountDuplicates(IEnumerable<string> items)
    {
        var seen = new HashSet<string>();
        int duplicates = 0;

        foreach (var item in items)
        {
            if (!seen.Add(item))
            {
                duplicates++;
            }
        }

        return duplicates;
    }
}
