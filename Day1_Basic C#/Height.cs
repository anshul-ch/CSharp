using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace CapgeminiTraining
{
    /// <summary>
    /// This program returns the height characterstics of a person
    /// </summary>
    public class Height
    {   
        /// <summary>
        /// this function returns the height characterstics
        /// </summary>
        /// <param name="height"></param>
        /// <returns> The predefined characterstics based on height </returns>
        public string CheckHeight(int height)
        {
            
            if (height < 150) return "Dwarf";
            if (height >= 150 && height < 165) return "Average";
            if (height >= 165 && height < 190) return "Tall";
            return "Abnormal";

        }
        /// <summary>
        /// Main program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            Height check_height = new Height();
            Console.WriteLine("Enter  a person's height in cm: ");
            int person_height = int.Parse(Console.ReadLine());
            string output = check_height.CheckHeight(person_height);
            Console.WriteLine(output);

        }
    }
}
