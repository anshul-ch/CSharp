using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class Customer_Support
    {
        static void Main()
        {
            var first = new List<int> {1,4,7};
            var second = new List<int> {2,3,8};

            var result = Merge(first, second);
            Console.WriteLine(string.Join(", ", result));
        }

        static List<int> Merge(List<int> first, List<int> second)
        {
            var merged = new List<int>();
            int i = 0, j = 0;

            while (i < first.Count && j < second.Count)
            {
                if (first[i] <= second[j])
                    merged.Add(first[i++]);
                else
                    merged.Add(second[j++]);
            }

            while (i < first.Count)
                merged.Add(first[i++]);

            while (j < second.Count)
                merged.Add(second[j++]);

            return merged;
        }
    }
}
