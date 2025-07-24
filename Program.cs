namespace FinalWeek10
{
    class Program
    {
        static void Main(string[] args)
        {
            Tests.Run();             // Run functional tests first
            PerformanceTests.Run();  // Then run performance tests
        }
    }
}

