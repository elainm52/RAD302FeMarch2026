using Tracker.WebAPIClient;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "Your ID", StudentName: "Your Name", activityName: "Rad302 FE 2026", Task: "Using Library Schema");
            Console.WriteLine("Hello, World!");
        }
    }
}
