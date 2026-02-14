using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class Movie_Booking
    {
        static void Main()
        {
            int number = 5;
            var alreadyBooked = new List<int> {2,4};
            int requestCount = 5;

            var result = AllocateSeats(number, alreadyBooked, requestCount);
            Console.WriteLine(string.Join(", ", result));
        }

        static List<int> AllocateSeats(int n, List<int> alreadyBooked, int requestCount)
        {
            var available = new SortedSet<int>();

            for (int i = 1; i <= n; i++)
                if (!alreadyBooked.Contains(i))
                    available.Add(i);

            var allocated = new List<int>();

            for (int i = 0; i < requestCount; i++)
            {
                if (available.Count > 0)
                {
                    int seat = available.Min;
                    allocated.Add(seat);
                    available.Remove(seat);
                }
                else
                {
                    allocated.Add(-1);
                }
            }

            return allocated;
        }
    }
}
