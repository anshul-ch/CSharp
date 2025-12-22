using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini_Training
{
    /// <summary>
    /// This program act as a calcualtor and run infinetly unitl a exit option is called.
    /// </summary>
    class Menu_System
    {
        static void Main(string[] args)
        {
            int choice;

            // do-while loop ensures menu runs at least once
            do
            {
                // Display menu options
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                // Read user choice
                choice = int.Parse(Console.ReadLine());

                // switch statement to handle menu options
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter first number: ");
                        int a1 = int.Parse(Console.ReadLine());
                        Console.Write("Enter second number: ");
                        int b1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Result = " + (a1 + b1));
                        break;

                    case 2:
                        Console.Write("Enter first number: ");
                        int a2 = int.Parse(Console.ReadLine());
                        Console.Write("Enter second number: ");
                        int b2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Result = " + (a2 - b2));
                        break;

                    case 3:
                        Console.Write("Enter first number: ");
                        int a3 = int.Parse(Console.ReadLine());
                        Console.Write("Enter second number: ");
                        int b3 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Result = " + (a3 * b3));
                        break;

                    case 4:
                        Console.Write("Enter first number: ");
                        int a4 = int.Parse(Console.ReadLine());
                        Console.Write("Enter second number: ");
                        int b4 = int.Parse(Console.ReadLine());

                        // Check to avoid division by zero
                        if (b4 != 0)
                            Console.WriteLine("Result = " + (a4 / b4));
                        else
                            Console.WriteLine("Division by zero is not allowed!");
                        break;

                    case 5:
                        Console.WriteLine("Exiting program... Thank you!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

            } while (choice != 5); // Loop continues until user selects Exit
        }
    }
}
