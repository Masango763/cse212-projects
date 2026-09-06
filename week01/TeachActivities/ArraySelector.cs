using System;
using System.Collections.Generic;

/// <summary>
/// Merges two source collections based on a binary control array.
/// </summary>
public class ArraySelector
{
    /// <summary>
    /// Combines elements from list1 and list2 driven by the select array.
    /// Enhanced with Generics <T> to accept any data type (int, string, custom objects)
    /// and Index Bounds Protection to prevent IndexOutOfRangeException crashes.
    /// Time Complexity: O(n) where n is select.Length.
    /// Space Complexity: O(n) to construct the output array.
    /// </summary>
    /// <typeparam name="T">Generic type parameter allowing reusability across data types.</typeparam>
    /// <param name="list1">First source array (selected when selector value is 1).</param>
    /// <param name="list2">Second source array (selected when selector value is 2).</param>
    /// <param name="select">Control array containing 1s and 2s.</param>
    /// <returns>A new array containing elements selected from list1 and list2.</returns>
    public static T[] ListSelector<T>(T[] list1, T[] list2, int[] select)
    {
        T[] result = new T[select.Length];
        int l1Index = 0;
        int l2Index = 0;

        for (int i = 0; i < select.Length; i++)
        {
            int control = select[i];

            if (control == 1)
            {
                // Boundary check: Protect against reading past array bounds
                if (l1Index >= list1.Length)
                {
                    throw new IndexOutOfRangeException($"Selector requested item from list1 at step {i}, but list1 is exhausted.");
                }
                result[i] = list1[l1Index++];
            }
            else if (control == 2)
            {
                // Boundary check: Protect against reading past array bounds
                if (l2Index >= list2.Length)
                {
                    throw new IndexOutOfRangeException($"Selector requested item from list2 at step {i}, but list2 is exhausted.");
                }
                result[i] = list2[l2Index++];
            }
            else
            {
                throw new ArgumentException($"Invalid control flag '{control}' at index {i}. Expected 1 or 2.");
            }
        }

        return result;
    }
}
