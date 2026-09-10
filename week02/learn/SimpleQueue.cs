using System;
using System.Collections.Generic;

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
