using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    public class Node
    {
        public int Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(int data)
        {
            Data = data;
        }
    }

    public Node? Head => _head;
    public Node? Tail => _tail;

    public bool HeadAndTailAreNull()
    {
        return _head == null && _tail == null;
    }

    public bool HeadAndTailAreNotNull()
    {
        return _head != null && _tail != null;
    }

    public void InsertHead(int value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    public void RemoveHead()
    {
        if (_head == null)
            return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            if (_head.Next != null)
                _head.Next.Prev = null;
            _head = _head.Next;
        }
    }

    public void InsertTail(int value)
    {
        Node newNode = new Node(value);
        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            if (_tail != null)
                _tail.Next = newNode;
            _tail = newNode;
        }
    }

    public void RemoveTail()
    {
        if (_tail == null)
            return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            if (_tail != null)
                _tail.Next = null;
        }
    }

    public void InsertAfter(int oldValue, int newValue)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                if (current == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new Node(newValue);
                    newNode.Prev = current;
                    newNode.Next = current.Next;
                    if (current.Next != null)
                        current.Next.Prev = newNode;
                    current.Next = newNode;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void Remove(int value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data == value)
            {
                if (current == _head)
                {
                    RemoveHead();
                }
                else if (current == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                }
                return;
            }
            current = current.Next;
        }
    }

    public void Replace(int oldValue, int newValue)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }
            current = current.Next;
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        var current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<int> Reverse()
    {
        var current = _tail;
        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }
}

public static class LinkedListExtensions
{
    public static string AsString(this IEnumerable<int> list)
    {
        return "<IEnumerable>{" + string.Join(", ", list) + "}";
    }
}
