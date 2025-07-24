using System; // Needed to use Console
using System.Diagnostics; // Needed to use Stopwatch for timing

namespace Week12_Final_Project
{
    public static class Performance
    {
        public static void MeasurePerformance()
        {
            // Define different queue sizes we want to test
            int[] sizes = { 10, 100, 1000, 10000, 100000 };

            // Number of times to repeat each test to get a better average
            int repetitions = 5;

            // Loop through each size
            foreach (int trials in sizes)
            {
                Console.WriteLine($"\nPerformance test with {trials} elements:");

                // Warm-up: run some operations to avoid JIT impact
                var warmupQueue = new LLQueue<int>();
                warmupQueue.Enqueue(1);          
                warmupQueue.Peek();              
                warmupQueue.Contains(1);         
                warmupQueue.Dequeue();           

                // Variables to store total time for Enqueue and Dequeue
                double totalEnqueue = 0;
                double totalDequeue = 0;

                // Run the same test multiple times to get a stable average
                for (int run = 0; run < repetitions; run++)
                {
                    var queue = new LLQueue<int>(); // Create a fresh queue

                    // Run garbage collection to reduce memory noise
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    // Measure Enqueue time
                    Stopwatch sw = Stopwatch.StartNew();
                    for (int i = 0; i < trials; i++)
                        queue.Enqueue(i);
                    sw.Stop();
                    totalEnqueue += sw.ElapsedTicks / (double)trials;

                    // Clean memory again before next test
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    // Measure Dequeue time
                    sw.Restart();
                    for (int i = 0; i < trials; i++)
                        queue.Dequeue();
                    sw.Stop();
                    totalDequeue += sw.ElapsedTicks / (double)trials;
                }

                // After all repetitions, calculate and round the final averages
                int avgEnqueue = (int)Math.Round(totalEnqueue / repetitions);
                int avgDequeue = (int)Math.Round(totalDequeue / repetitions);

                // Print Enqueue and Dequeue times as integers
                Console.WriteLine($"Average Enqueue time: {avgEnqueue} ticks");
                Console.WriteLine($"Average Dequeue time: {avgDequeue} ticks");

                // Now test Contains (just once, since it's O(n))
                var testQueue = new LLQueue<int>();
                for (int i = 0; i < trials; i++)
                    testQueue.Enqueue(i);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                Stopwatch swContains = Stopwatch.StartNew();
                testQueue.Contains(trials / 2); // Search for middle element
                swContains.Stop();
                Console.WriteLine($"Contains time: {swContains.ElapsedTicks} ticks");

                // Test Peek (also just once)
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                Stopwatch swPeek = Stopwatch.StartNew();
                testQueue.Peek(); // Look at first element
                swPeek.Stop();
                Console.WriteLine($"Peek time: {swPeek.ElapsedTicks} ticks");
            }
        }
    }
}
