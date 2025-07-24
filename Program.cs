using System; // Console demo

namespace Week12_Final_Project
{
    class Program
    {   
        /* This Program file is used for manual testing of the LLQueue<T> class.
        It creates a queue, adds items, removes items, checks the front item,
        verifies if a value exists, and shows the queue size.
        It helps confirm that the queue functions work before running formal unit tests.
        */
        
        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            var queue = new LLQueue<string>(); // Create a new queue instance for strings
            queue.Enqueue("Hello");
            queue.Enqueue("World");

            Console.WriteLine($"Queue size: {queue.Size}");
            Console.WriteLine($"First item: {queue.Peek()}");
            Console.WriteLine($"Dequeue item: {queue.Dequeue()}");
            Console.WriteLine($"Queue size after dequeue: {queue.Size}");
            
            // Manual performance test
            Console.WriteLine("\n");
            Performance.MeasurePerformance();
        }
    }
}