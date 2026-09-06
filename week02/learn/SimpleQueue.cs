using System;
using System.Collections.Generic;

/// <summary>
/// CSE 212: Week 02 Learning Activity - SimpleQueue Implementation
/// 
/// PLAN & ARCHITECTURE:
/// - Data Structure: Dynamic Array (List<int>) implementing a First-In, First-Out (FIFO) Queue abstraction.
/// - Enqueue Behavior: Append items to the back of the queue (index _queue.Count).
///   - Time Complexity: O(1) amortized.
/// - Dequeue Behavior: Extract and remove items from the front of the queue (index 0).
///   - Time Complexity: O(n) due to element shifting upon index 0 removal.
/// - Guard Clauses: Validate state prior to Dequeue; throw IndexOutOfRangeException on empty queue.
/// </summary>
public class SimpleQueue
{
    private List<int> _queue = new List<int>();

    /// <summary>
    /// Gets the current element count in the queue.
    /// Time Complexity: O(1)
    /// </summary>
    public int Length => _queue.Count;

    /// <summary>
    /// Enqueues an integer value to the back of the queue.
    /// Time Complexity: O(1) amortized
    /// </summary>
    /// <param name="value">The integer to append.</param>
    public void Enqueue(int value)
    {
        // PLAN: Add value to the back of the list
        _queue.Add(value);
    }

    /// <summary>
    /// Removes and returns the integer from the front of the queue (index 0).
    /// Time Complexity: O(n)
    /// </summary>
    /// <returns>The front item from the queue.</returns>
    /// <exception cref="IndexOutOfRangeException">Thrown when queue is empty.</exception>
    public int Dequeue()
    {
        // PLAN Step 1: Guard Clause - Check for empty queue
        if (_queue.Count == 0)
        {
            throw new IndexOutOfRangeException("Error: Cannot dequeue from an empty queue.");
        }

        // PLAN Step 2: Retrieve front item at index 0 (FIFO requirement)
        var value = _queue[0];

        // PLAN Step 3: Remove item at index 0 to shift remaining elements
        _queue.RemoveAt(0);

        // PLAN Step 4: Return extracted value
        return value;
    }

    /// <summary>
    /// Generates a string representation of the internal queue array.
    /// Time Complexity: O(n)
    /// </summary>
    public override string ToString()
    {
        return $"Queue Contents: [{string.Join(", ", _queue)}]";
    }
}
