using System;
using System.Collections.Generic;
using System.Diagnostics;

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
    /// Executes the unit tests called by Program.cs.
    /// </summary>
    public static void Run()
    {
        // Test 1
        // Scenario: Enqueue 100, 200, 300 and dequeue them all.
        // Expected Result: 100, 200, 300 in FIFO order.
        Console.WriteLine("Test 1");
        var queue = new SimpleQueue();
        queue.Enqueue(100);
        queue.Enqueue(200);
        queue.Enqueue(300);
        var value = queue.Dequeue();
        Trace.Assert(value == 100, $"Expected 100, got {value}");
        value = queue.Dequeue();
        Trace.Assert(value == 200, $"Expected 200, got {value}");
        value = queue.Dequeue();
        Trace.Assert(value == 300, $"Expected 300, got {value}");
        Console.WriteLine("Test 1 Passed!");

        // Test 2
        // Scenario: Interleaved Enqueue and Dequeue operations.
        // Expected Result: Items returned in exact arrival order.
        Console.WriteLine("\nTest 2");
        queue = new SimpleQueue();
        queue.Enqueue(100);
        queue.Enqueue(200);
        value = queue.Dequeue();
        Trace.Assert(value == 100, $"Expected 100, got {value}");
        queue.Enqueue(300);
        value = queue.Dequeue();
        Trace.Assert(value == 200, $"Expected 200, got {value}");
        value = queue.Dequeue();
        Trace.Assert(value == 300, $"Expected 300, got {value}");
        Console.WriteLine("Test 2 Passed!");

        // Test 3
        // Scenario: Dequeue on an empty queue.
        // Expected Result: Throws IndexOutOfRangeException.
        Console.WriteLine("\nTest 3");
        queue = new SimpleQueue();
        try
        {
            queue.Dequeue();
            Console.WriteLine("Test 3 Failed: Exception was not thrown.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Test 3 Passed (IndexOutOfRangeException caught)!");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Test 3 Failed: Unexpected exception type ({e.GetType().Name}).");
        }
    }

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
        var val = _queue[0];

        // PLAN Step 3: Remove item at index 0 to shift remaining elements
        _queue.RemoveAt(0);

        // PLAN Step 4: Return extracted value
        return val;
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
