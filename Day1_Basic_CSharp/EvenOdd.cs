using System;
using System.Collections.Generic;
using System.Text;


namespace CSharp.Day1_Basic_CSharp
{
    /// <summary>
    /// THis program checks whether a number is even or odd.
    /// </summary>
    public class EvenOdd
    {
        /// <summary>
        /// THis function checks for even or odd.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True or False </returns>
        public bool IsEven(int number)
        {
            return (number % 2 == 0);
        }
        public static void Main(String[] args)
        {
            EvenOdd even_func = new EvenOdd();
            Console.WriteLine("Enter a number to check Even or Odd (q for Quit");
            string? userInput = Console.ReadLine();
            int localNum = 0;
            bool result = false;
            string output = string.Empty;
            while(userInput != "q" && userInput != "Q") 
            {
                localNum = int.TryParse(userInput, out localNum) ? localNum : 0;
                result = even_func.IsEven(localNum);
                output = result ? "Even" : "Odd";
                Console.WriteLine(output);
            }
        }
    }
}
