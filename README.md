# CSE 212: Programming with Data Structures

This repository contains data structures and algorithm implementations for CSE 212.

## Repository Structure

- **`week01/`**: Introduction to Data Structures & Performance Analysis
- **`week02/`**: Stacks and Queues
  - `code/PersonQueue.cs`: FIFO queue implementation for persons.
  - `code/TakingTurnsQueue.cs`: Turn-based queue handling finite and infinite turns.
  - `code/PriorityQueue.cs`: Priority-based queue with custom item ordering and tie-breakers.
  - `code/*_Tests.cs`: Unit test suites with documented results.
  - `teach/ComplexStack.cs`: Balanced symbol checker utilizing `Stack<char>`.
  - `teach/CustomerService.cs`: Queue-based customer service implementation with defect fixes and edge-case guards.
- **`week03/`**: Sets and Maps
  - `learn/DuplicateCounter.cs`: Duplicate item counter utilizing `HashSet<T>` for O(1) membership testing.
  - `learn/Translator.cs`: Word translation dictionary utilizing `Dictionary<TKey, TValue>` for key-value lookups.
  - `learn/Program.cs`: Local test runner executing set and map learning activities.

## Getting Started

To run any C# module or test suite locally using the .NET CLI:

```bash
cd week03/learn
dotnet run
- week03/code/SetsAndMaps.cs: Hash set and dictionary implementations for finding pairs, summarizing census degree frequencies, anagram verification, and real-time earthquake data parsing.
