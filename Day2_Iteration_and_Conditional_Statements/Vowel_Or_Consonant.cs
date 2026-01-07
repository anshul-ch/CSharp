using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// Checks if a character is Vowel or consonant
    /// </summary>
    class Vowel_Or_Consonant
    {
        static void Main(string[] args)
        {
            // Ask user to enter a character
            Console.Write("Enter a character: ");
            char ch = char.ToLower(Console.ReadLine()[0]);

            // Switch statement to check vowel
            switch (ch)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("It is a Vowel");
                    break;

                default:
                    Console.WriteLine("It is a Consonant");
                    break;
            }

           
        }
    }
}
