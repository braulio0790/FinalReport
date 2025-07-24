using System; // Required for Console
using System.Collections.Generic; // Required for List<T>
using System.Diagnostics; // Required for Stopwatch

namespace FinalWeek10
{
    public class PerformanceTests
    {
        // This method runs performance tests for different queue sizes
        public static void Run()
        {
            Console.WriteLine("\nRunning performance tests...\n");

            // Define the test sizes (number of elements)
            int[] sizes = { 10, 100, 1000, 10000, 100000 };

            // How many times we repeat the test to get an average
            int repetitions = 5;

            // Loop through each test size
            foreach (int size in sizes)
            {
                Console.WriteLine($"--- Testing with queue size: {size} ---");

                double totalEnqueue = 0;
                double totalPeek = 0;
                double totalContains = 0;
                double totalDequeue = 0;

                // Run the tests multiple times to reduce noise
                for (int run = 0; run < repetitions; run++)
                {
                    // Create and fill the queue
                    var queue = new LQueue<int>();
                    for (int i = 0; i < size; i++)
                        queue.Enqueue(i);

                    // Run garbage collector to reduce background noise
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    // Enqueue one extra item and measure time
                    Stopwatch sw = Stopwatch.StartNew();
                    queue.Enqueue(-1);
                    sw.Stop();
                    totalEnqueue += sw.ElapsedTicks;

                    // Peek performance test
                    GC.Collect();
                    sw.Restart();
                    queue.Peek();
                    sw.Stop();
                    totalPeek += sw.ElapsedTicks;

                    // Contains test (search for middle value)
                    GC.Collect();
                    sw.Restart();
                    queue.Contains(size / 2);
                    sw.Stop();
                    totalContains += sw.ElapsedTicks;

                    // Dequeue one item
                    GC.Collect();
                    sw.Restart();
                    queue.Dequeue();
                    sw.Stop();
                    totalDequeue += sw.ElapsedTicks;
                }

                // Show the average result (rounded to nearest tick)
                Console.WriteLine($"Enqueue time: {(int)(totalEnqueue / repetitions)} ticks");
                Console.WriteLine($"Peek time: {(int)(totalPeek / repetitions)} ticks");
                Console.WriteLine($"Contains time: {(int)(totalContains / repetitions)} ticks");
                Console.WriteLine($"Dequeue time: {(int)(totalDequeue / repetitions)} ticks\n");
            }

            Console.WriteLine("Performance tests completed.");
        }
    }
}

