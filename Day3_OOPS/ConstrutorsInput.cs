using System;
using System.Collections.Generic;
using System.Text;
using CapgeminiTraining.ConstructorsEX;  // to use the Construcor file templates

namespace CapgeminiTraining
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
