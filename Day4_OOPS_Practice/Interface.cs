using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day4_OOPS_Practice
{
    /// <summary>
    /// This program implements the Interface, In interface it is must to implement it's methods if inherited.
    /// In abstraction there is only a semi object ype, it's methods are completed in child class.
    /// </summary>
    public interface IPrint
    {
         public void print();
    }

    public class Functionality : IPrint
    {
        public void print()
        {
            Console.WriteLine("Printing Done");
        }
    }
    public class Interface
    {
        public static void Main(String[] args)
        {
            Functionality printFunction = new Functionality();
            printFunction.print();
        }
    }
}
