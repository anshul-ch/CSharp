using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class Undo_Feature
    {
        static void Main()
        {
            var ops = new List<string>
            {
                "TYPE Hello",
                "TYPE World",
                "UNDO",
                "TYPE CSharp"
            };

            Console.WriteLine(ProcessOps(ops));
        }

        static string ProcessOps(List<string> ops)
        {
            var stack = new Stack<string>();

            foreach (var op in ops)
            {
                if (op.StartsWith("TYPE "))
                {
                    var word = op.Substring(5);
                    stack.Push(word);
                }
                else if (op == "UNDO" && stack.Count > 0)
                {
                    stack.Pop();
                }
            }

            return string.Join(" ", stack.ToArray().Reverse());
        }
    }
}
