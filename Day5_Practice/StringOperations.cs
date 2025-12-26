using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day5_Practice
{
    public class StringCleaning
    {
        public string CleanseAndInvert(string input)
        {
            if (string.IsNullOrEmpty(input) || input.Length < 6)
            {
                return string.Empty;
            }

            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return string.Empty;
                }
            }

            // filtered is the new string input after removing even placed ASCII characters
            string lowerInput = input.ToLower();
            string filtered = "";

            foreach (char c in lowerInput)
            {
                if ((int)c % 2 != 0)
                {
                    filtered += c;
                }
            }

            char[] charArray = filtered.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);

            // to make the even placed characters UpperCase after reversing.
            StringBuilder finalResult = new StringBuilder();
            for (int i = 0; i < reversed.Length; i++)
            {
                if (i % 2 == 0)
                {
                    finalResult.Append(char.ToUpper(reversed[i]));
                }
                else
                {
                    finalResult.Append(reversed[i]);
                }
            }

            return finalResult.ToString();
        }

    }

    public class StringOperations
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter a string input: ");
            string input = Console.ReadLine();
            StringCleaning stringCleaning = new StringCleaning();
            string result = stringCleaning.CleanseAndInvert(input);
            Console.WriteLine(result);
    }
    }
}
