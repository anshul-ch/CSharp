using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini_Training
{
    /// <summary>
    /// This program calculates electricity bill based on units Consumed.
    /// </summary>
    public class Electricity_Bill
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Units Consumed: ");
            double unitsConsumed = double.Parse(Console.ReadLine());
            double FinalBill = 0;
            if(unitsConsumed < 200)
            {
                FinalBill = unitsConsumed * 1.20;
            }
            else if(unitsConsumed>=200 && unitsConsumed < 400)
            {
                FinalBill = unitsConsumed * 1.50;
            }
            else if(unitsConsumed>=400 && unitsConsumed < 600)
            {
                FinalBill = unitsConsumed * 1.80;
            }
            else if (unitsConsumed >= 600)
            {
                FinalBill = unitsConsumed * 2.0;
            }
            if (FinalBill > 400)
            {
                FinalBill *= 11.5;
            }

            Console.WriteLine("Your Electricity Bill is: " + FinalBill);
        }
    }
}
