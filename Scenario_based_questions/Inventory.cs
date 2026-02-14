using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class Inventory
    {
        static void Main()
        {
            var serials = new List<string>
            {
                "S1","S2","S1","S3","S2","S2"
            };

            var result = DetectDuplicates(serials);
            Console.WriteLine(string.Join(", ", result));
        }

        static List<string> DetectDuplicates(List<string> serials)
        {
            var seen = new HashSet<string>();
            var duplicates = new HashSet<string>();
            var result = new List<string>();

            foreach (var serial in serials)
            {
                if (!seen.Add(serial) && duplicates.Add(serial))
                    result.Add(serial);
            }

            return result;
        }
    }
}
