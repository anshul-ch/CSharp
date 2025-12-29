using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day6
{
    /// <summary>
    /// Provides extension methods for string manipulation, including palindrome checking and string reversal.
    /// </summary>
    /// <remarks>This class contains static methods that extend the functionality of the <see cref="string"/>
    /// type. All methods are thread-safe and can be used as extension methods on string instances.</remarks>
    public static class StringExtensions
    {
        public static bool Palindrome(this string str)
        {
            return str == ReverseString(str);
        }
        /// <summary>
        /// Returns a new string with the characters of the specified string in reverse order.
        /// </summary>
        /// <param name="str">The string to reverse. Cannot be null.</param>
        /// <returns>A new string whose characters are in the reverse order of those in <paramref name="str"/>.</returns>
        public static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
    public class MethodExtension
    {
        public static void Main(String[] args)
        {
            string testString = "Hello world";
            bool isCapitalized = testString.Palindrome();
            Console.WriteLine($"Is the string '{testString}' Palindrome? {isCapitalized}");
        }
    }
}
