using System;

namespace CSharp.Scenario_based_questions
{
    class Marksheet
    {
        static void CalculateResult(
            int[] marks,
            out int total,
            out double avg,
            out string result)
        {
            total = 0;
            bool isPass = true;

            for (int i = 0; i < marks.Length; i++)
            {
                total += marks[i];

                if (marks[i] < 35)
                {
                    isPass = false;
                }
            }

            avg = (double)total / marks.Length;
            result = isPass ? "Pass" : "Fail";
        }

        static void Main()
        {
            int[] marks = { 78, 65, 40, 55, 90 };

            CalculateResult(marks, out int total, out double avg, out string result);

            Console.WriteLine("Total: " + total);
            Console.WriteLine("Average: " + avg);
            Console.WriteLine("Result: " + result);
        }
    }
}
