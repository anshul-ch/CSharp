using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    public class StringBuilder_Performance
    {
        static void Main(String[] args)
        {
            const int count = 100000;
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            string log1 = "";
            for (int i = 1; i <= count; i++)
            {
                log1 = log1 + "Log entry number: " + i + "\n";
            }
            stopwatch1.Stop();
            Console.WriteLine("time without StringBuilder: " + stopwatch1.ElapsedMilliseconds);
            stopwatch1.Reset();

            stopwatch1.Start();
            StringBuilder log2 = new StringBuilder();
            for(int i = 0; i < count; i++)
            {
                log2.Append("Log entry number: ");
                log2.Append(i);
                log2.Append('\n');
            }
            stopwatch1.Stop();
            Console.WriteLine("WIth StringBuilder: " + stopwatch1.ElapsedMilliseconds);


            
        }
    }
}

          
          
      
