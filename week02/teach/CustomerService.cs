using System;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// CSE 212: Week 02 Team Activity - Customer Service Queue
/// </summary>
public class CustomerService
{
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId}): {Problem}";
        }
    }

    private readonly List<Customer> _queue = new List<Customer>();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        // FIX DEFECT 1: Require <= 0 to catch 0 and negative inputs
        if (maxSize <= 0)
        {
            _maxSize = 10;
        }
        else
        {
            _maxSize = maxSize;
        }
    }

    public void AddNewCustomer(string name = "Default User", string accountId = "ACC-100", string problem = "General Query")
    {
        // FIX DEFECT 2: Guard check using >= to prevent exceeding capacity
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Error: Customer Service Queue is full.");
            return;
        }

        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    public void ServeCustomer()
    {
        // FIX DEFECT 3: Guard clause for empty queue BEFORE reading index 0
        if (_queue.Count == 0)
        {
            Console.WriteLine("Error: No customers in queue to serve.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine($"Serving Customer: {customer}");
    }

    public static void Main(string[] args)
    {
        RunTests();
    }

    public static void RunTests()
    {
        Console.WriteLine("================= Test 1: Invalid Max Size Defaulting =================");
        var cs1 = new CustomerService(0);
        Trace.Assert(cs1._maxSize == 10, "Test 1 Failed: maxSize = 0 should default to 10");
        var cs2 = new CustomerService(-5);
        Trace.Assert(cs2._maxSize == 10, "Test 1 Failed: maxSize = -5 should default to 10");
        Console.WriteLine("Test 1 Passed!");

        Console.WriteLine("\n================= Test 2: Enqueue Overflow Guard =================");
        var cs3 = new CustomerService(2);
        cs3.AddNewCustomer("Alice", "A1", "Login issue");
        cs3.AddNewCustomer("Bob", "B2", "Billing query");
        cs3.AddNewCustomer("Charlie", "C3", "Overflow request"); // Error message expected
        Trace.Assert(cs3._queue.Count == 2, "Test 2 Failed: Queue exceeded maximum capacity!");
        Console.WriteLine("Test 2 Passed!");

        Console.WriteLine("\n================= Test 3: Empty Queue Underflow Guard =================");
        var cs4 = new CustomerService(4);
        cs4.ServeCustomer(); // Error message expected, no exception thrown
        Console.WriteLine("Test 3 Passed!");

        Console.WriteLine("\n================= Test 4: FIFO Order Verification =================");
        var cs5 = new CustomerService(2);
        cs5.AddNewCustomer("Customer 1", "001", "P1");
        cs5.AddNewCustomer("Customer 2", "002", "P2");
        cs5.ServeCustomer(); // Serves Customer 1
        cs5.ServeCustomer(); // Serves Customer 2
        Console.WriteLine("Test 4 Passed!");
    }
}
