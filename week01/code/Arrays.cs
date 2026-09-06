using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'count' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) results in <double>{7, 14, 21, 28, 35}.
    /// </summary>
    /// <param name="number">The starting double number</param>
    /// <param name="count">The number of multiples to generate</param>
    /// <returns>An array of doubles containing the calculated multiples</returns>
    public static double[] MultiplesOf(double number, int count)
    {
        // =========================================================================
        // PLAN: MultiplesOf
        // Step 1: Allocate a new double array of fixed length equal to 'count'.
        // Step 2: Loop through each index i from 0 up to (count - 1).
        // Step 3: For each iteration, compute the multiple using: number * (i + 1).
        // Step 4: Assign the computed product into the array at index i.
        // Step 5: Return the populated array of doubles.
        // =========================================================================

        double[] multiples = new double[count];

        for (int i = 0; i < count; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// For example, if data is <List>{1, 2, 3, 4, 5, 6, 7, 8, 9} and amount is 5,
    /// the result will be <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}.
    /// </summary>
    /// <param name="data">The list of integers to rotate</param>
    /// <param name="amount">The number of positions to rotate right</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // =========================================================================
        // PLAN: RotateListRight
        // Step 1: Calculate the effective rotation amount using modulo (amount % data.Count)
        //         to account for full loop-around rotations.
        // Step 2: Determine the split index where the list divides: splitIndex = data.Count - rotation.
        // Step 3: Extract the trailing 'rotation' elements using data.GetRange(splitIndex, rotation).
        // Step 4: Extract the leading 'splitIndex' elements using data.GetRange(0, splitIndex).
        // Step 5: Clear the original list using data.Clear().
        // Step 6: Append the trailing slice back to data first using data.AddRange(rightPart).
        // Step 7: Append the leading slice back to data second using data.AddRange(leftPart).
        // =========================================================================

        if (data == null || data.Count == 0) return;

        int rotation = amount % data.Count;
        if (rotation == 0) return;

        int splitIndex = data.Count - rotation;

        List<int> rightPart = data.GetRange(splitIndex, rotation);
        List<int> leftPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
