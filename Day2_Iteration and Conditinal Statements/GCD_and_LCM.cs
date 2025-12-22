using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Capgemini_Training
{
    /// <summary>
    /// This program finds GCD and LCM of two numebers
    /// </summary>
    class GCD_LCM
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter first number:");
            int num1 = int.Parse(Console.ReadLine());

           
            Console.WriteLine("Enter second number:");
            int num2 = int.Parse(Console.ReadLine());

            int a = num1;
            int b = num2;

            //  GCD CALCULATION
            while (b != 0)
            {
                int remainder = a % b; 
                a = b;                 
                b = remainder;        
            }

            int gcd = a; // Final value of a is GCD

            //  LCM CALCULATION 
            int lcm = (num1 * num2) / gcd;

            Console.WriteLine("GCD = " + gcd);
            Console.WriteLine("LCM = " + lcm);
        }
    }
}
