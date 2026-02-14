using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Scenario_based_questions
{
    class Log_analyzer
    {
        static void Main()
        {
            var codes = new List<string>
            {
                "E02","E01","E02","E01","E03"
            };

            Console.WriteLine(MostFrequent(codes));
        }

        static string MostFrequent(List<string> codes)
        {
            var freq = new Dictionary<string, int>();

            foreach (var code in codes)
            {
                if (!freq.ContainsKey(code))
                    freq[code] = 0;

                freq[code]++;
            }

            return freq
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key)
                .First()
                .Key;
        }
    }
}
