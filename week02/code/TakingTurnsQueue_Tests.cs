using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace week02.code;

[TestClass]
public class TakingTurnsQueue_Tests
{
    // Test Results: Passed. Finite turns decrease correctly and person leaves queue when turns reach zero.
    [TestMethod]
    public void TestTakingTurnsQueue_FiniteTurns()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", 2);
        queue.AddPerson("Tim", 1);

        var p1 = queue.GetNextPerson();
        Assert.AreEqual("Bob", p1.Name);

        var p2 = queue.GetNextPerson();
        Assert.AreEqual("Tim", p2.Name);

        var p3 = queue.GetNextPerson();
        Assert.AreEqual("Bob", p3.Name);
        Assert.AreEqual(1, p3.Turns);
    }

    // Test Results: Passed. Infinite turns (<= 0) loop back into the queue indefinitely.
    [TestMethod]
    public void TestTakingTurnsQueue_InfiniteTurns()
    {
        var queue = new TakingTurnsQueue();
        queue.AddPerson("Bob", -1);

        var p1 = queue.GetNextPerson();
        var p2 = queue.GetNextPerson();

        Assert.AreEqual("Bob", p1.Name);
        Assert.AreEqual("Bob", p2.Name);
    }
}
