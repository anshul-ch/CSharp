using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini_Training
{
    /// <summary>
    /// This program checks if a year is leap year or not 
    /// </summary>
    public class Leap_Year_Checker
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            if (year % 400 == 0)
            {
                Console.WriteLine(year + " is a Leap Year!");
            }
            else if (year % 4 == 0 && year % 100 != 0)
            {
                Console.WriteLine(year + " is a Leap Year!");
            }
            else
            {
                Console.WriteLine(year + " is not a Leap Year!");
            }
        }

    }
}
