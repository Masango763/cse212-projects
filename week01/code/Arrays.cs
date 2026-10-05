using System;
using System.Collections.Generic;

/// <summary>
/// Provides utility methods for dynamic array and list manipulations.
/// Strictly conforms to CSE 212 method signatures while providing
/// optimal O(n) performance, boundary protection, and inline documentation.
/// </summary>
public static class Arrays
{
    /// <summary>
    /// Generates an array of size 'count' containing sequential multiples of 'number'.
    /// For example, MultiplesOf(7, 5) results in <double>{7, 14, 21, 28, 35}.
    /// </summary>
    /// <param name="number">The starting double value to generate multiples for.</param>
    /// <param name="count">The total number of multiples to compute.</param>
    /// <returns>An array of doubles containing the calculated multiples.</returns>
    public static double[] MultiplesOf(double number, int count)
    {
        // =========================================================================
        // PLAN: MultiplesOf (Rubric Criterion 1)
        // Step 1: Validate input parameter 'count'. If count is 0 or negative,
        //         return an empty double array immediately to prevent invalid allocation.
        // Step 2: Allocate a fixed-size double array named 'multiples' of length 'count'.
        // Step 3: Loop through array indices i from 0 up to (count - 1).
        // Step 4: Calculate each multiple value using the formula: number * (i + 1).
        // Step 5: Store each computed value into the 'multiples' array at position [i].
        // Step 6: Return the fully populated 'multiples' array.
        //
        // Complexity:
        // - Time Complexity: O(n) where n = count (single linear pass).
        // - Space Complexity: O(n) memory allocation for the return array.
        // =========================================================================

        // Guard Clause: Handle non-positive count values safely
        if (count <= 0)
        {
            return Array.Empty<double>();
        }

        // Step 2: Memory allocation
        double[] multiples = new double[count];

        // Step 3-5: Linear generation pass
        for (int i = 0; i < count; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 6: Return final result
        return multiples;
    }

    /// <summary>
    /// Rotates the elements of 'data' to the right by 'amount' positions in-place.
    /// For example, rotating <List>{1, 2, 3, 4, 5, 6, 7, 8, 9} by 5 yields <List>{5, 6, 7, 8, 9, 1, 2, 3, 4}.
    /// </summary>
    /// <param name="data">The list of integers to rotate.</param>
    /// <param name="amount">The number of positions to shift elements rightward.</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // =========================================================================
        // PLAN: RotateListRight (Rubric Criterion 3)
        // Step 1: Check for edge cases. If 'data' is null or contains fewer than 2 elements,
        //         no rotation is needed; exit early.
        // Step 2: Compute the effective rotation amount using modulo arithmetic:
        //         effectiveAmount = amount % data.Count.
        // Step 3: Handle potential negative rotation values by wrapping around:
        //         if effectiveAmount < 0, add data.Count to make it positive.
        // Step 4: If effectiveAmount evaluates to 0 (no movement required), exit early.
        // Step 5: Calculate the split index: splitIndex = data.Count - effectiveAmount.
        // Step 6: Extract the trailing elements (shifted to front) using GetRange(splitIndex, effectiveAmount).
        // Step 7: Extract the leading elements (shifted to back) using GetRange(0, splitIndex).
        // Step 8: Clear the original list using data.Clear().
        // Step 9: Re-assemble the list by adding the trailing slice first, followed by the leading slice.
        //
        // Complexity:
        // - Time Complexity: O(n) where n = data.Count (single list slicing pass).
        // - Space Complexity: O(n) temporary list slicing memory during swap.
        // =========================================================================

        // Guard Clause 1: Validate list existence and size
        if (data == null || data.Count <= 1)
        {
            return;
        }

        // Step 2 & 3: Normalize rotation amount for wrap-around and negative inputs
        int effectiveAmount = amount % data.Count;
        if (effectiveAmount < 0)
        {
            effectiveAmount += data.Count;
        }

        // Guard Clause 2: Skip operation if net rotation is zero
        if (effectiveAmount == 0)
        {
            return;
        }

        // Step 5: Compute partition threshold
        int splitIndex = data.Count - effectiveAmount;

        // Step 6 & 7: Extract list slices
        List<int> rightPart = data.GetRange(splitIndex, effectiveAmount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        // Step 8 & 9: In-place list reconstruction
        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
