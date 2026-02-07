using System;
using System.Collections.Generic;

namespace CSharp.Adv_Practice
{
    public class RateLimiter
{
    private List<DateTime> requestTimes = new List<DateTime>();
    private object rateLock = new object();

    private const int MAX_REQUESTS = 5;
    private static readonly TimeSpan WINDOW = TimeSpan.FromSeconds(10);

    public bool AllowRequest(DateTime now)
    {
        lock (rateLock)
        {
            // remove old requests
            requestTimes.RemoveAll(t => now - t > WINDOW);

            if (requestTimes.Count >= MAX_REQUESTS)
            {
                return false; // blocked
            }

            requestTimes.Add(now);
            return true; // allowed
        }
    }
}
class Rate_Limiter
    {
        public static void Main(String[] args){
        var limiter = new RateLimiter();
        for (int i = 0; i < 6; i++)
        {
            bool allowed = limiter.AllowRequest(DateTime.Now);
            Console.WriteLine($"is {i} request allowed {allowed}");
        }
        }
    }
}