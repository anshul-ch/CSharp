using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiTraining
{
    /// <summary>
    /// This program checks if an Integer is Palindrome or not.
    /// </summary>
    public  class Palindrome
    {
        /// <summary>
        /// This function reverse an Integer and checks if it's palindrome
        /// </summary>
        /// <param name="number"></param>
        /// <returns> True or False </returns>
        
        public bool Int_Reverse(int number)
        {
            int reverse = 0;
            int original = number;
            while (number > 0)
            {
                int lastdigit = number % 10;
                reverse = (reverse * 10) + lastdigit;
                number = number / 10;
            }
            
            if (reverse==original) return true;
            return false;


        }
        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter a number to check Palindrome: ");
            Palindrome int_reverse = new Palindrome();
            int number = int.Parse(Console.ReadLine());
            bool output = int_reverse.Int_Reverse(number);
            Console.WriteLine(output);
        }
    }
}
