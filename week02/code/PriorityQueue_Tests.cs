using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace week02.code;

[TestClass]
public class PriorityQueue_Tests
{
    // Test Results: Passed. Item with highest priority is removed first.
    [TestMethod]
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());
        Assert.AreEqual("Medium", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    // Test Results: Passed. FIFO order is preserved for items with matching priorities.
    [TestMethod]
    public void TestPriorityQueue_TieBreakerFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
    }
}
