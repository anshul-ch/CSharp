using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    // Class to determine the quadrant of a point (x, y)
    public class Quadrant_Finder
    {
        // Main method: Entry point of the program
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter X Co-ordinate: ");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y Co-ordinate: ");
            double y = double.Parse(Console.ReadLine());

            if (x > 0 && y > 0)
            {
                Console.WriteLine("1st Quadrant!");
            }

            else if (x < 0 && y > 0)
            {
                Console.WriteLine("2nd Quadrant!");
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine("3rd Quadrant!");
            }
            else
            {
                Console.WriteLine("4th Quadrant!");
            }
        }
    }
}
