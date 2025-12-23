using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day4_OOPS_Practice
{
    /// <summary>
    /// This program implements the Interface, In interface it is must to implement 
    /// (they are rules/structure that all have to follow)
    /// In abstraction they methods are used by child classes, they can only use these but cannot be changed.
    /// (they give you the fucntionality but not shown how it is done.)
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
