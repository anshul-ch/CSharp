using System;
using System.Collections.Generic;

namespace CSharp.Scenario_based_questions
{
    class Bank_StateMent
    {
        static void Main()
        {
            var txns = new List<(string category, decimal amount)>
            {
                ("Food",-200),
                ("Fuel",-500),
                ("Food",-50),
                ("Salary",1000)
            };

            var result = SpendByCategory(txns);

            foreach (var kv in result)
                Console.WriteLine($"{kv.Key}: {kv.Value}");
        }

        static Dictionary<string, decimal> SpendByCategory(List<(string category, decimal amount)> txns)
        {
            var spend = new Dictionary<string, decimal>();

            foreach (var txn in txns)
            {
                if (txn.amount < 0)
                {
                    if (!spend.ContainsKey(txn.category))
                        spend[txn.category] = 0;

                    spend[txn.category] += Math.Abs(txn.amount);
                }
            }

            return spend;
        }
    }
}
