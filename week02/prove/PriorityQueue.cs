using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// CSE 212: Week 02 Prove - Priority Queue Implementation & Unit Tests
/// 
/// PLAN & ARCHITECTURE:
/// - PriorityItem: Encapsulates item value (string) and numeric priority (int).
/// - Enqueue: Appends new PriorityItem to the back of the queue (O(1) time complexity).
/// - Dequeue: Scans queue from index 0 to _queue.Count - 1, selects highest priority item,
///   removes it from internal storage, and returns its value (O(n) time complexity).
/// - FIFO Tie-Breaking: Uses strict '>' inequality so earliest enqueued item wins priority ties.
/// </summary>
public class PriorityQueue
{
    private List<PriorityItem> _queue = new List<PriorityItem>();

    private class PriorityItem
    {
        public string Value { get; }
        public int Priority { get; }

        public PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }

    /// <summary>
    /// Enqueues an item with an assigned priority to the back of the queue.
    /// Time Complexity: O(1)
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newItem = new PriorityItem(value, priority);
        _queue.Add(newItem);
    }

    /// <summary>
    /// Finds, removes, and returns the highest priority item.
    /// Breaks priority ties using First-In, First-Out (FIFO) ordering.
    /// Time Complexity: O(n)
    /// </summary>
    /// <returns>Value of the highest priority item.</returns>
    /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
    public string Dequeue()
    {
        // Guard Clause: Throw InvalidOperationException on empty queue
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Error: The queue is empty.");
        }

        // Find index of item with highest priority
        var highPriorityIndex = 0;
        
        // FIX DEFECT 1: Loop bound scans all elements (index < _queue.Count)
        for (int index = 1; index < _queue.Count; index++)
        {
            // FIX DEFECT 2: Use '>' instead of '>=' to preserve FIFO ordering for equal priorities
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // Retrieve highest priority value
        var value = _queue[highPriorityIndex].Value;

        // FIX DEFECT 3: Remove dequeued item from internal storage
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }

    /// <summary>
    /// Entry point and unit test suite verifying all rubric requirements.
    /// </summary>
    public static void Main(string[] args)
    {
        RunTests();
    }

    public static void RunTests()
    {
        // Test 1: Dequeue Highest Priority Item
        Console.WriteLine("================= Test 1 =================");
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 2);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);
        var result = pq.Dequeue();
        Console.WriteLine($"Test 1 Dequeue: {result} (Expected: High)");
        Trace.Assert(result == "High", "Test 1 Failed!");
        Console.WriteLine("Test 1 Passed!");

        // Test 2: FIFO Tie-Breaking
        Console.WriteLine("\n================= Test 2 =================");
        pq = new PriorityQueue();
        pq.Enqueue("FirstHigh", 10);
        pq.Enqueue("Low", 1);
        pq.Enqueue("SecondHigh", 10);
        result = pq.Dequeue();
        Console.WriteLine($"Test 2 Dequeue: {result} (Expected: FirstHigh)");
        Trace.Assert(result == "FirstHigh", "Test 2 Failed!");
        Console.WriteLine("Test 2 Passed!");

        // Test 3: Last Element Priority (Loop Bound Inspection)
        Console.WriteLine("\n================= Test 3 =================");
        pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("TailMax", 99);
        result = pq.Dequeue();
        Console.WriteLine($"Test 3 Dequeue: {result} (Expected: TailMax)");
        Trace.Assert(result == "TailMax", "Test 3 Failed!");
        Console.WriteLine("Test 3 Passed!");

        // Test 4: Empty Queue Exception Handling
        Console.WriteLine("\n================= Test 4 =================");
        pq = new PriorityQueue();
        try
        {
            pq.Dequeue();
            Console.WriteLine("Test 4 Failed: No exception thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Test 4 Passed: Caught expected exception -> {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test 4 Failed: Unexpected exception type ({ex.GetType().Name})");
        }
    }
}
