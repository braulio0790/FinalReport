using System;
using System.Collections.Generic;

namespace FinalWeek10
{
    public class Tests
    {
        // This method runs all the test methods one by one
        public static void Run()
        {
            Console.WriteLine("Running basic queue tests...\n");

            // Calling all functions at once
            EnqueueTest();
            DequeueTest();
            PeekTest();
            ContainsTest();
            DequeueFromEmptyTest();
            PeekFromEmptyTest();
            
            // This method will show how List<T> increases its capacity
            TestCapacityGrowth();

            Console.WriteLine("\nAll tests completed.");
        }

        // Test Enqueue adds an item and Size updates
        static void EnqueueTest()
        {
            LQueue<string> queue = new LQueue<string>();
            queue.Enqueue("apple");

            if (queue.Size == 1)
            {
                Console.WriteLine("EnqueueTest passed");
            }
            else
            {
                Console.WriteLine($"EnqueueTest failed. Size was {queue.Size} instead of 1");
            }
        }

        // Test Dequeue removes the first item
        static void DequeueTest()
        {
            LQueue<string> queue = new LQueue<string>();
            queue.Enqueue("first");
            queue.Enqueue("second");
            string removed = queue.Dequeue();

            if (removed == "first" && queue.Size == 1)
            {
                Console.WriteLine("DequeueTest passed");
            }
            else
            {
                Console.WriteLine("DequeueTest failed");
            }
        }

        // Test Peek returns first item without removing it
        static void PeekTest()
        {
            LQueue<int> queue = new LQueue<int>();
            queue.Enqueue(10);
            int value = queue.Peek();

            if (value == 10 && queue.Size == 1)
            {
                Console.WriteLine("PeekTest passed");
            }
            else
            {
                Console.WriteLine("PeekTest failed");
            }
        }

        // Test Contains checks if a value exists
        static void ContainsTest()
        {
            LQueue<string> queue = new LQueue<string>();
            queue.Enqueue("one");
            queue.Enqueue("two");

            if (queue.Contains("two"))
            {
                Console.WriteLine("ContainsTest passed");
            }
            else
            {
                Console.WriteLine("ContainsTest failed");
            }
        }

        // Test Dequeue throws error when queue is empty
        static void DequeueFromEmptyTest()
        {
            LQueue<int> queue = new LQueue<int>();

            try
            {
                queue.Dequeue();
                Console.WriteLine("DequeueFromEmptyTest failed (no exception)");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("DequeueFromEmptyTest passed");
            }
        }

        // Test Peek throws error when queue is empty
        static void PeekFromEmptyTest()
        {
            LQueue<int> queue = new LQueue<int>();

            try
            {
                queue.Peek();
                Console.WriteLine("PeekFromEmptyTest failed (no exception)");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("PeekFromEmptyTest passed");
            }
        }
        
        // This function shows how List<T> grows its internal capacity
        // It measures how items the list can hold before it resizes
        // The idea is to show when the pattern change
        static void TestCapacityGrowth()
        {
            LQueue<int> queue = new LQueue<int>();

            Console.WriteLine("\nTesting internal capacity growth... the value after '=' shows when the capacity changes.");

            // Capacity is a property from the List<T> class in the .NET standard library, and it measures how many items the list can hold before it resizes.
            int previousCapacity = queue.Capacity;

            for (int i = 0; i < 100; i++)
            {
                queue.Enqueue(i);

                // If the capacity has changed, we print it
                if (queue.Capacity != previousCapacity)
                {
                    Console.WriteLine($"Capacity changed: {previousCapacity} -> {queue.Capacity} at Size = {queue.Size}");
                    previousCapacity = queue.Capacity;
                }
            }
        }
    }
}

