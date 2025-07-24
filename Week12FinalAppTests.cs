using NUnit.Framework; // Import NUnit for test cases
using Week12_Final_Project; // Reference to the queue implementation

namespace Week12FinalAppTests
{
    public class Tests // Test class containing all unit tests for LLQueue<T>.
    {
        [Test] // Marks the following method as a test case.
        public void EnqueueAndSizeTest() // Test if Enqueue works and Size property updates correctly.
        {
            var queue = new LLQueue<string>(); // Create a new instance for strings
            queue.Enqueue("A"); // Add first item to the queue
            queue.Enqueue("B"); // Add second item to the queue
            Assert.That(queue.Size, Is.EqualTo(2)); // Confirm that the queue now contains exactly 2 items
        }

        [Test] // Marks the following method as a test case.
        public void DequeueTest() // Test if Dequeue returns the correct item and updates Size.
        {
            var queue = new LLQueue<string>(); // Create a new instance for strings
            queue.Enqueue("A"); // Add first item to the queue
            queue.Enqueue("B"); // Add second item to the queue
            Assert.That(queue.Dequeue(), Is.EqualTo("A")); // Confirm that Dequeue returns the first item ("A") and removes it from the queue
            Assert.That(queue.Size, Is.EqualTo(1)); // Confirm that the queue now contains exactly 1 item
        }

        [Test] // Marks the following method as a test case.
        public void PeekTest() // Test if Peek returns the correct item without removing it.
        {
            var queue = new LLQueue<string>(); // Create a new instance for strings
            queue.Enqueue("A"); // Add first item to the queue
            Assert.That(queue.Peek(), Is.EqualTo("A")); // Confirm that Peek shows the first item ("A") without removing it
            Assert.That(queue.Size, Is.EqualTo(1)); // Confirm that the queue now contains exactly 1 item
        }

        [Test] // Marks the following method as a test case.
        public void ContainsTest() // Test if Contains correctly identifies existing and non-existing items.
        {
            var queue = new LLQueue<string>(); // Create a new instance for strings
            queue.Enqueue("A"); // Add first item to the queue
            Assert.That(queue.Contains("A"), Is.True); // Confirm that Contains returns true when the item exists in the queue
            Assert.That(queue.Contains("B"), Is.False); // Confirm that Contains returns false when the item does not exist in the queue
        }

        [Test] // Marks the following method as a test case.
        public void DequeueEmptyThrows() // Test if Dequeue throws exception when queue is empty.
        {
            var queue = new LLQueue<string>(); // Create a new instance for strings
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue()); // Confirm that Dequeue throws exception when queue is empty
        }

        [Test] // Marks the following method as a test case.
        public void PeekEmptyThrows() // Test if Peek throws exception when queue is empty.
        {
            var queue = new LLQueue<string>(); // Create a new instance for strings
            Assert.Throws<InvalidOperationException>(() => queue.Peek()); // Confirm that Peek throws an exception when the queue is empty
        }
    }
}
