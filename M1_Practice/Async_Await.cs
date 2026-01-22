using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.M1_Practice
{
    /// <summary>
    /// Demonstrates the use of:
    /// 1. Traditional Threading
    /// 2. Async / Await programming
    /// within a single console application.
    /// </summary>
    public class Async_Await
    {
        /// <summary>
        /// Application entry point.
        /// This method remains synchronous and safely
        /// invokes asynchronous code using GetAwaiter().GetResult().
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("===== APPLICATION STARTED =====\n");
            
            
            // Create two threads for even and odd number printing
            Thread evenThread = new Thread(PrintEvenNumbers);
            Thread oddThread = new Thread(PrintOddNumbers);

            // Start both threads
            evenThread.Start();
            oddThread.Start();

            // Wait until both threads finish execution
            evenThread.Join();
            oddThread.Join();

            Console.WriteLine("\n\n===== THREADING COMPLETED =====\n");

            // -------------------------------------------------
            // PART 2: ASYNC / AWAIT EXAMPLE
            // -------------------------------------------------

            // Create instance to call non-static async method
            Async_Await example = new Async_Await();

            // Call async workflow from synchronous Main method
            // GetAwaiter().GetResult() prevents deadlocks
            example.RunAsyncWorkflow().GetAwaiter().GetResult();

            Console.WriteLine("\n===== APPLICATION FINISHED =====");
            Console.ReadLine();
        }

        /// <summary>
        /// Coordinates all asynchronous operations.
        /// Acts as a controller method for async workflow.
        /// </summary>
        /// <returns>A Task representing the async execution</returns>
        public async Task RunAsyncWorkflow()
        {
            Console.WriteLine("Starting async workflow...\n");

            // Fetch data from a remote API asynchronously
            string apiResponse = await FetchDataAsync(
                "https://jsonplaceholder.typicode.com/todos/1"
            );

            // Print API response
            Console.WriteLine("API Response:");
            Console.WriteLine(apiResponse);
            Console.WriteLine();

            // Simulate a long-running asynchronous task
            await SimulateLongRunningTask();
        }

        /// <summary>
        /// Simulates a long-running asynchronous operation
        /// without blocking the main thread.
        /// </summary>
        /// <returns>A Task representing the delay</returns>
        private static async Task SimulateLongRunningTask()
        {
            Console.WriteLine("Async task started...");

            // Non-blocking delay of 3 seconds
            await Task.Delay(3000);

            Console.WriteLine("Async task completed after 3 seconds.");
        }

        /// <summary>
        /// Fetches data asynchronously from a given URL using HttpClient.
        /// </summary>
        /// <param name="url">API endpoint</param>
        /// <returns>Response content as a string</returns>
        private static async Task<string> FetchDataAsync(string url)
        {
            // HttpClient should be disposed after use
            using HttpClient client = new HttpClient();

            // Asynchronously fetch response content
            return await client.GetStringAsync(url);
        }

        /// <summary>
        /// Prints even numbers using a separate thread.
        /// Demonstrates traditional multithreading.
        /// </summary>
        private static void PrintEvenNumbers()
        {
            Console.WriteLine("Even numbers:");

            for (int i = 0; i < 20; i += 2)
            {
                // Pause execution to visualize threading
                Thread.Sleep(100);
                Console.Write(i + " ");
            }
        }

        /// <summary>
        /// Prints odd numbers using a separate thread.
        /// Demonstrates traditional multithreading.
        /// </summary>
        private static void PrintOddNumbers()
        {
            Console.WriteLine("\nOdd numbers:");

            for (int i = 1; i < 20; i += 2)
            {
                // Pause execution to visualize threading
                Thread.Sleep(150);
                Console.Write(i + " ");
            }
        }
    }
}
