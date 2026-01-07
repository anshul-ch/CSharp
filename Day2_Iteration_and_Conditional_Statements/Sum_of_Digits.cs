using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    class Digital_Root
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter a number:");
            int num = int.Parse(Console.ReadLine());

            
            while (num >= 10)
            {
                int sum = 0;

                // Calculate sum of digits
                while (num > 0)
                {
                    int digit = num % 10;   
                    sum += digit;           
                    num /= 10;             
                }

                num = sum;
            }

            Console.WriteLine("Digital Root is: " + num);
        }
    }
}

