namespace Week11FinalApp
{
    class Program
    {
        /* This Program file is used for manual testing of the AQueue<T> class.
        It creates a queue, adds items, removes items, checks the front item, 
        verifies if a value exists, and shows the queue size.
        It helps confirm that the queue functions work before running formal unit tests.
        */
        
        static void Main(string[] args)
        {
            // Create a queue with capacity 5
            AQueue<int> queue = new AQueue<int>(5);

            // Add some items
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            // Quick manual testing
            Console.WriteLine("**Testing Message**");
            
            // Show front item without removing
            Console.WriteLine("\nFront item: " + queue.Peek());

            // Remove an item
            Console.WriteLine("Dequeue: " + queue.Dequeue());

            // Show new front item
            Console.WriteLine("New front: " + queue.Peek());

            // Check if it contains a value
            Console.WriteLine("Contains 20: " + queue.Contains(20));

            // Show size of the queue
            Console.WriteLine("Size: " + queue.Size);
            Console.ResetColor(); // Reset color to default
            
            // Manual performance test
            Console.WriteLine("\n");
            PerformanceTest.RunPerformanceTest();
        }
    }
}

