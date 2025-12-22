using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini_Training
{
        class Valid_Date_Check
        {
            static void Main(string[] args)
            {
                
                Console.WriteLine("Enter Day:");
                int day = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Month:");
                int month = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Year:");
                int year = int.Parse(Console.ReadLine());

                bool isValid = true;
                if (month < 1 || month > 12)
                {
                    isValid = false;
                }
                else
                {
                    // Days in each month
                    int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                    // Check for leap year for month of Feb
                    if (month == 2 && IsLeapYear(year))
                    {
                        daysInMonth[1] = 29;
                    }

                    if (day < 1 || day > daysInMonth[month - 1])
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    Console.WriteLine("Valid Date");
                }
                else
                {
                    Console.WriteLine("Invalid Date");
                }
            }

            static bool IsLeapYear(int year)
            {
                return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
            }
        }
    

}
