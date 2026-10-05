using System;
using System.Collections.Generic;
using System.Linq;

public static class Recursion
{
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        currPath ??= new List<(int, int)>();
        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        if (maze.IsValidMove(currPath, x + 1, y))
            SolveMaze(results, maze, x + 1, y, currPath);
        if (maze.IsValidMove(currPath, x - 1, y))
            SolveMaze(results, maze, x - 1, y, currPath);
        if (maze.IsValidMove(currPath, x, y + 1))
            SolveMaze(results, maze, x, y + 1, currPath);
        if (maze.IsValidMove(currPath, x, y - 1))
            SolveMaze(results, maze, x, y - 1, currPath);

        currPath.RemoveAt(currPath.Count - 1);
    }

    // ============================================================
    // 1. Sum Squares Recursive
    // ============================================================

    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return (n * n) + SumSquaresRecursive(n - 1);
    }


    // ============================================================
    // 2. Permutations Choose
    // ============================================================




    // ============================================================
    // 3. Count Ways To Climb
    // ============================================================

    public static decimal CountWaysToClimb(
        int s,
        Dictionary<int, decimal>? remember = null)
    {
        if (s == 0)
            return 1;

        if (s < 0)
            return 0;

        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.TryGetValue(s, out decimal saved))
            return saved;

        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;

        return ways;
    }


    // ============================================================
    // 4. Wildcard Binary
    // ============================================================

    public static void WildcardBinary(
        string pattern,
        List<string> results,
        int index = 0)
    {
        // Find the next wildcard.
        int wildcardIndex = pattern.IndexOf('*', index);

        // No more wildcards.
        if (wildcardIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace wildcard with 0.
        string pattern0 =
            pattern.Substring(0, wildcardIndex) +
            "0" +
            pattern.Substring(wildcardIndex + 1);

        WildcardBinary(
            pattern0,
            results,
            wildcardIndex + 1);

        // Replace wildcard with 1.
        string pattern1 =
            pattern.Substring(0, wildcardIndex) +
            "1" +
            pattern.Substring(wildcardIndex + 1);

        WildcardBinary(
            pattern1,
            results,
            wildcardIndex + 1);
    }


    // Alias in case the project uses this name.
    public static void WildcardBinaryPatterns(
        string pattern,
        List<string> results)
    {
        WildcardBinary(pattern, results);
    }


    // ============================================================
    // 5. Solve Maze
    // ============================================================







    // ============================================================
    // Maze Helpers
    // ============================================================



}


// ================================================================
// Extension Method for Maze Paths
// ================================================================

public static class ListExtensions
{
    public static string AsString(
        this List<(int, int)> path)
    {
        return "<List>{" + string.Join(", ", path.Select(p => $"({p.Item1}, {p.Item2})")) + "}";
    }
}
