using System;
using System.Collections.Generic;
using System.Diagnostics;

public class SimpleQueue
{
    private readonly List<int> _queue = new List<int>();

    public void Enqueue(int value)
    {
        // Requirement: Enqueue adds the item to the back of the queue
        _queue.Add(value);
    }

    public int Dequeue()
    {
        // Requirement: If empty, throw IndexOutOfRangeException
        if (_queue.Count == 0)
        {
            throw new IndexOutOfRangeException("The queue is empty.");
        }

        // Requirement: Dequeue removes and returns the item from the front of the queue
        int value = _queue[0];
        _queue.RemoveAt(0);
        return value;
    }

    public int Count => _queue.Count;
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("================= Testing SimpleQueue (Learn Activity) =================");

        var queue = new SimpleQueue();

        // Test 1: Enqueue and Dequeue order (FIFO)
        queue.Enqueue(100);
        queue.Enqueue(200);
        queue.Enqueue(300);

        int val1 = queue.Dequeue();
        Console.WriteLine($"Dequeued: {val1} (Expected: 100)");
        Trace.Assert(val1 == 100, "Test 1 Failed: Expected 100");

        int val2 = queue.Dequeue();
        Console.WriteLine($"Dequeued: {val2} (Expected: 200)");
        Trace.Assert(val2 == 200, "Test 1 Failed: Expected 200");

        int val3 = queue.Dequeue();
        Console.WriteLine($"Dequeued: {val3} (Expected: 300)");
        Trace.Assert(val3 == 300, "Test 1 Failed: Expected 300");

        // Test 2: Underflow Exception check
        try
        {
            queue.Dequeue();
            throw new Exception("Test 2 Failed: Expected IndexOutOfRangeException was not thrown.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Test 2 Passed: Successfully caught IndexOutOfRangeException on empty queue.");
        }

        Console.WriteLine("\nAll SimpleQueue learn activity tests passed successfully!");
    }
}
