using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// THis program finds the largest of 3 numbers
    /// </summary>
    public class Largest_of_Three
    {
        static void Main(string[] args)
        {
            int a, b, c;
            Console.WriteLine("Enter first number: ");
            a=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number: ");
            b=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Third number: ");
            c=int.Parse(Console.ReadLine());
            if(a>b && a > c)
            {
                Console.WriteLine("Largest number is " + a);
            }
            else if(b>a && b > c)
            {
                Console.WriteLine("Largest number is " + b);
            }
            else
            {
                Console.WriteLine("Largest number is " + c);
            }
        }
    }
}
