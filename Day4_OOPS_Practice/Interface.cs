using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day4_OOPS_Practice
{
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
