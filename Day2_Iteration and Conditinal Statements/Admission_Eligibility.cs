using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program CVheck for admission eligiblity based on subject marks
    /// </summary>
    public class Admission_Eligibility
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter marks in Mathematics, Physics and Chemistry respectively:");
            int Math=int.Parse(Console.ReadLine());
            int Phys=int.Parse(Console.ReadLine());
            int Chem=int.Parse(Console.ReadLine());
            int Total= Math + Phys + Chem;
            bool isEligible = false;
            if(Math>=65 && Phys>=55 && Chem>=50 && (Total>=180 || (Math + Phys >= 140))){
                isEligible = true;
            }

            if (isEligible == true)
            {
                Console.WriteLine("You are Eligible for Admission!");
                
            }
            else
            {
                Console.WriteLine("You are not Eligible for Admission!");
            }
        }
    }
}
