using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day3_OOPS
{
    /// <summary>
    /// This code contains the addition of 2 numbers using constructors.
    /// </summary>
    public class ConstructorAdd
    {
        int number1 { get; set; }
        int number2 { get; set; }
        int result { get;}

        public ConstructorAdd(int num1, int num2)
        {
            this.number1 = num1;
            this.number2 = num2;
            result = number1 + number2;
        }
        public int Output()
        {
            return result;
        }
    }
    public class ConstructorAddition
    {
        public static void Main(String[] args)
        {
            ConstructorAdd addition = new ConstructorAdd(10, 20);
            Console.WriteLine("addition of two numbers is :"+addition.Output());
        }
    }
}
