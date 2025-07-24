using System;
using System.Diagnostics;

namespace Week11FinalApp
{
    public class PerformanceTest
    {
        public static void RunPerformanceTest()
        {
            int[] testSizes = { 10,100, 1000, 10000, 100000 }; // Queue sizes to test
            int repetitions = 5; // Number of times to repeat tests for averaging

            foreach (int size in testSizes)
            {
                Console.WriteLine($"\n--- Testing with queue size: {size} ---");

                // Warm-up to avoid JIT delays
                var warmup = new AQueue<int>(10);
                warmup.Enqueue(1);
                warmup.Peek();
                warmup.Contains(1);
                warmup.Dequeue();

                // === Enqueue test ===
                double totalEnqueueTicks = 0;

                for (int r = 0; r < repetitions; r++)
                {
                    var queue = new AQueue<int>(size);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    Stopwatch sw = Stopwatch.StartNew();
                    for (int i = 0; i < size; i++)
                        queue.Enqueue(i);
                    sw.Stop();

                    totalEnqueueTicks += sw.ElapsedTicks / (double)size;
                }

                int avgEnqueue = (int)(totalEnqueueTicks / repetitions);
                Console.WriteLine($"Enqueue time: {avgEnqueue} ticks");

                // === Contains test ===
                var containsQueue = new AQueue<int>(size);
                for (int i = 0; i < size; i++)
                    containsQueue.Enqueue(i);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                Stopwatch swContains = Stopwatch.StartNew();
                containsQueue.Contains(size / 2);
                swContains.Stop();

                Console.WriteLine($"Contains time: {swContains.ElapsedTicks} ticks");

                // === Peek test ===
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                Stopwatch swPeek = Stopwatch.StartNew();
                containsQueue.Peek();
                swPeek.Stop();

                Console.WriteLine($"Peek time: {swPeek.ElapsedTicks} ticks");

                // === Dequeue test ===
                double totalDequeueTicks = 0;

                for (int r = 0; r < repetitions; r++)
                {
                    var queue = new AQueue<int>(size);
                    for (int i = 0; i < size; i++)
                        queue.Enqueue(i);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();

                    Stopwatch sw = Stopwatch.StartNew();
                    for (int i = 0; i < size; i++)
                        queue.Dequeue();
                    sw.Stop();

                    totalDequeueTicks += sw.ElapsedTicks / (double)size;
                }

                int avgDequeue = (int)(totalDequeueTicks / repetitions);
                Console.WriteLine($"Dequeue time: {avgDequeue} ticks");
            }

            Console.ResetColor();
        }
    }
}
