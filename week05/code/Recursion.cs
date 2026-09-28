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

    // This is the signature used by the tests:
    // PermutationsChoose(List<string>, string, int, List<string>)
    public static void PermutationsChoose(
        List<string> letters,
        string word,
        int size,
        List<string> results)
    {
        // Stop when the requested word length is reached.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // If there are no more letters, stop.
        if (letters.Count == 0)
            return;

        for (int i = 0; i < letters.Count; i++)
        {
            // Make a copy so each recursive branch has its own
            // remaining letters.
            List<string> remaining = new List<string>(letters);

            string chosen = remaining[i];

            remaining.RemoveAt(i);

            PermutationsChoose(
                remaining,
                word + chosen,
                size,
                results);
        }
    }

    // Convenience overload in case another test calls:
    // PermutationsChoose(letters, size, results)
    public static void PermutationsChoose(
        List<string> letters,
        int size,
        List<string> results)
    {
        PermutationsChoose(
            letters,
            "",
            size,
            results);
    }


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

    // Main recursive maze method.
    public static void SolveMaze(
        int[] maze,
        int size,
        int x,
        int y,
        List<(int, int)> currPath,
        List<string> results)
    {
        // Make sure this position is valid.
        if (!IsValidMove(
                maze,
                size,
                x,
                y,
                currPath))
        {
            return;
        }

        // Add current position to the path.
        currPath.Add((x, y));

        // If we reached the bottom-right corner,
        // save the complete path.
        if (IsEnd(maze, size, x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Move right.
            SolveMaze(
                maze,
                size,
                x + 1,
                y,
                currPath,
                results);

            // Move left.
            SolveMaze(
                maze,
                size,
                x - 1,
                y,
                currPath,
                results);

            // Move down.
            SolveMaze(
                maze,
                size,
                x,
                y + 1,
                currPath,
                results);

            // Move up.
            SolveMaze(
                maze,
                size,
                x,
                y - 1,
                currPath,
                results);
        }

        // Backtrack.
        currPath.RemoveAt(currPath.Count - 1);
    }


    // Two-argument version.
    //
    // The tests expect SolveMaze(maze, size), so this version
    // creates the results list and returns it.
    public static List<string> SolveMaze(
        int[] maze,
        int size)
    {
        List<string> results = new List<string>();

        SolveMaze(
            maze,
            size,
            0,
            0,
            new List<(int, int)>(),
            results);

        return results;
    }


    // Three-argument version, retained for compatibility.
    public static void SolveMaze(
        int[] maze,
        int size,
        List<string> results)
    {
        SolveMaze(
            maze,
            size,
            0,
            0,
            new List<(int, int)>(),
            results);
    }


    // ============================================================
    // Maze Helpers
    // ============================================================

    private static bool IsValidMove(
        int[] maze,
        int size,
        int x,
        int y,
        List<(int, int)> currPath)
    {
        // Outside maze.
        if (x < 0 || x >= size ||
            y < 0 || y >= size)
        {
            return false;
        }

        // Cell is blocked.
        if (maze[y * size + x] == 0)
            return false;

        // Already visited this cell.
        if (currPath.Contains((x, y)))
            return false;

        return true;
    }


    private static bool IsEnd(
        int[] maze,
        int size,
        int x,
        int y)
    {
        return x == size - 1 &&
               y == size - 1;
    }
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