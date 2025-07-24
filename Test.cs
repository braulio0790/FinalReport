using NUnit.Framework; // Import NUnit framework for unit testing
using Week11FinalApp; // Import project namespace to access AQueue class

namespace Week11FinalAppTests // Define a new namespace for test files
{
    public class Test // Create a public class to hold the tests
    {
        [Test] // This marks the method as a unit test
        public void TestEnqueueDequeue() // Test Enqueue and Dequeue behavior
        {
            // Create a small queue for testing with capacity 3
            var queue = new AQueue<string>(3);

            // Add two items to the queue
            queue.Enqueue("A");
            queue.Enqueue("B");

            // Check that dequeue gives the correct value ("A"), first in first out
            Assert.That(queue.Dequeue(), Is.EqualTo("A"));

            // Check that peek shows the next value ("B") without removing it
            Assert.That(queue.Peek(), Is.EqualTo("B"));
        }

        [Test] // Mark this method as a test case
        public void TestContains() // Test Contains method behavior
        {
            // Create a queue with capacity 3
            var queue = new AQueue<string>(3); 

            // Add item "X" to the queue
            queue.Enqueue("X"); 

            // Confirm queue contains "X" (should be true)
            Assert.That(queue.Contains("X"), Is.True);

            // Confirm queue does not contain "Y" (should be false)
            Assert.That(queue.Contains("Y"), Is.False);
        }

        [Test] // Mark this method as a test case
        public void TestQueueFullException() // Test behavior when queue is full
        {
            var queue = new AQueue<int>(2); // Create a queue with capacity 2

            queue.Enqueue(1); // Add first item
            queue.Enqueue(2); // Add second item (queue now full)

            // Check that adding one more item throws InvalidOperationException
            Assert.That(() => queue.Enqueue(3), Throws.TypeOf<InvalidOperationException>());
        }

        [Test] // Mark this method as a test case
        // Test behavior when queue is empty
        public void TestQueueEmptyException() 
        {
            // Create a queue with capacity 2
            var queue = new AQueue<int>(2); 

            // Check that dequeue throws an exception because the queue is empty
            Assert.That(() => queue.Dequeue(), Throws.TypeOf<InvalidOperationException>());

            // Check that peek throws an exception because the queue is empty
            Assert.That(() => queue.Peek(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}