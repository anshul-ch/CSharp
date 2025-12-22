using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day3_OOPS
{
    /// <summary>
    /// Usage of private and public constructors
    /// </summary>
    public class ConstrutorsInput
    {
        public static void Main(String[] args)
        {
            // Constructors constructor = new Constructors(); // will give error as
                                                             // default construcotr is private.

            Constructors constructor = new Constructors(123, "Anshul", "IT");
            Constructors constructors = new Constructors("Shrey", "R&D");



        }
    }
}
