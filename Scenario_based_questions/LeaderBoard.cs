using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Scenario_based_questions
{
    class LeaderBoard
    {
        static void Main()
        {
            var players = new List<(string name, int score)>
            {
                ("Raj",80),
                ("Anu",95),
                ("Vikram",95),
                ("Meena",70)
            };

            int k = 3;

            var result = TopK(players, k);

            foreach (var p in result)
                Console.WriteLine($"{p.name}: {p.score}");
        }

        static List<(string name, int score)> TopK(List<(string name, int score)> players, int k)
        {
            return players
                .OrderByDescending(p => p.score)
                .ThenBy(p => p.name)
                .Take(k)
                .ToList();
        }
    }
}
