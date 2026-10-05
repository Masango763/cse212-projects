using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ComplexStack
{
    public static bool DoSomethingComplicated(string line)
    {
        var stack = new Stack<char>();
        foreach (var item in line)
        {
            if (item is '(' or '[' or '{')
            {
                stack.Push(item);
            }
            else if (item is ')')
            {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']')
            {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}')
            {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("================= ComplexStack Unit Tests =================");

        // Test Input 1: Balanced brackets -> Expected: True
        string test1 = "(a == 3 or (b == 5 and c == 6))";
        bool result1 = DoSomethingComplicated(test1);
        Console.WriteLine($"Test 1 Result: {result1} (Expected: True)");
        Trace.Assert(result1 == true, "Test 1 Failed!");

        // Test Input 2: Mismatched brackets -> Expected: False
        string test2 = "(students]i].Grade > 80 and students[i].Grade < 90)";
        bool result2 = DoSomethingComplicated(test2);
        Console.WriteLine($"Test 2 Result: {result2} (Expected: False)");
        Trace.Assert(result2 == false, "Test 2 Failed!");

        // Test Input 3: Missing final closing bracket -> Expected: False
        string test3 = "(robot[id + 1].Execute(.Pass() || (!robot[id * (2 + i)].Alive && stormy) || (robot[id - 1].Alive && lavaFlowing))";
        bool result3 = DoSomethingComplicated(test3);
        Console.WriteLine($"Test 3 Result: {result3} (Expected: False)");
        Trace.Assert(result3 == false, "Test 3 Failed!");

        Console.WriteLine("\nAll ComplexStack tests passed successfully!");
    }
}
