using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class Market_ticketing
    {
        static void Main()
        {
            var queue = new Queue<(TimeSpan entryTime, string ticketType)>();

            queue.Enqueue((TimeSpan.Parse("08:15"), "Regular"));
            queue.Enqueue((TimeSpan.Parse("09:30"), "Premium"));
            queue.Enqueue((TimeSpan.Parse("10:00"), "Regular"));
            queue.Enqueue((TimeSpan.Parse("07:50"), "Regular"));

            int result = CountPeakRegular(q);
            Console.WriteLine(result);
        }

        static int CountPeakRegular(Queue<(TimeSpan entryTime, string ticketType)> queue)
        {
            int count = 0;
            TimeSpan start = TimeSpan.Parse("08:00");
            TimeSpan end = TimeSpan.Parse("10:00");

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();

                if (item.ticketType == "Regular" &&
                    item.entryTime >= start &&
                    item.entryTime <= end)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
