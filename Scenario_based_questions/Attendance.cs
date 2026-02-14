using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class Attendance
    {
        static void Main()
        {
            var scans = new List<int> { 10, 20, 10, 30, 20, 40 };
            var result = FirstUnique(scans);

            Console.WriteLine(string.Join(", ", result));
        }

        static List<int> FirstUnique(List<int> scans)
        {
            var seen = new HashSet<int>();
            var firstTime = new List<int>();

            foreach (var id in scans)
            {
                if (!seen.Contains(id))
                {
                    seen.Add(id);
                    firstTime.Add(id);
                }
            }

            return firstTime;
        }
    }
}
