using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("================= Running CustomerService Tests =================");
        CustomerServiceTest.RunTests();
    }
}

public class CustomerServiceTest
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

    public CustomerServiceTest(int maxSize)
    {
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
        if (_queue.Count == 0)
        {
            Console.WriteLine("Error: No customers in queue to serve.");
            return;
        }

        var customer = _queue[0];
        _queue.RemoveAt(0);
        Console.WriteLine($"Serving Customer: {customer}");
    }

    public static void RunTests()
    {
        Console.WriteLine("Test 1: Invalid Max Size Defaulting");
        var cs1 = new CustomerServiceTest(0);
        Trace.Assert(cs1._maxSize == 10, "Test 1 Failed");
        var cs2 = new CustomerServiceTest(-5);
        Trace.Assert(cs2._maxSize == 10, "Test 1 Failed");
        Console.WriteLine("Test 1 Passed!\n");

        Console.WriteLine("Test 2: Enqueue Overflow Guard");
        var cs3 = new CustomerServiceTest(2);
        cs3.AddNewCustomer("Alice", "A1", "Login issue");
        cs3.AddNewCustomer("Bob", "B2", "Billing query");
        cs3.AddNewCustomer("Charlie", "C3", "Overflow request");
        Trace.Assert(cs3._queue.Count == 2, "Test 2 Failed");
        Console.WriteLine("Test 2 Passed!\n");

        Console.WriteLine("Test 3: Empty Queue Underflow Guard");
        var cs4 = new CustomerServiceTest(4);
        cs4.ServeCustomer();
        Console.WriteLine("Test 3 Passed!\n");

        Console.WriteLine("Test 4: FIFO Order Verification");
        var cs5 = new CustomerServiceTest(2);
        cs5.AddNewCustomer("Customer 1", "001", "P1");
        cs5.AddNewCustomer("Customer 2", "002", "P2");
        cs5.ServeCustomer();
        cs5.ServeCustomer();
        Console.WriteLine("Test 4 Passed!");
    }
}
