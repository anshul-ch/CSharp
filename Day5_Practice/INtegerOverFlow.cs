using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day5
{
    /// <summary>
    /// This code helps in avoiding Inter overflow and Round - robin understanding
    /// </summary>
    public class INtegerOverFlow
    {
        static void Main(String[] args)
        {
            Calculate calculate = new Calculate();
            int input1 = int.MaxValue;
            int input2 = 1;
            Console.WriteLine(calculate.Add1(input1, input2));
            Console.WriteLine(calculate.add(input1, input2));
        }

    }
    public class Calculate
    {
        public int Add1(int a, int b)
        {
            return a + b;
        }
        public int add(int a, int b)
        {
            checked    // by deafault C# doesn't throw Overflowing error, so to skip the round-robin, checked is used.
            {
                return a + b;
            }
        }
    }
}
