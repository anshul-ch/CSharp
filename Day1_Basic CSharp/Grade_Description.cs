using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day1_Basic_CSharp
{
    /// <summary>
    /// THis program finds a student proficiency based on grades scored. 
    /// </summary>
        class Grade_Description
        {
            static void Main(string[] args)
            {
                // Ask the user to enter a grade
                Console.WriteLine("Enter Grade (E, V, G, A, F): ");

                // Read the input and convert it to uppercase to handle lowercase input
                char grade = char.ToUpper(Console.ReadLine()[0]);

                // Switch statement to check grade and print description
                switch (grade)
                {
                    case 'E':
                        Console.WriteLine("Excellent");
                        break;

                    case 'V':
                        Console.WriteLine("Very Good");
                        break;

                    case 'G':
                        Console.WriteLine("Good");
                        break;

                    case 'A':
                        Console.WriteLine("Average");
                        break;

                    case 'F':
                        Console.WriteLine("Fail");
                        break;

                    default:
                        // Handles invalid grade input
                        Console.WriteLine("Invalid Grade Entered");
                        break;
                }

                // Keeps console window open until a key is pressed
                Console.ReadKey();
            }
        }
}
