using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// THis program calculate Profit or loss % based on SP and CP.
    /// </summary>
    class Profit_Loss
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter Cost Price:");
            double costPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Selling Price:");
            double sellingPrice = double.Parse(Console.ReadLine());

            if (sellingPrice > costPrice)
            {
                double profit = sellingPrice - costPrice;

                double profitPercent = (profit / costPrice) * 100;

                Console.WriteLine("Profit Occurred");
                Console.WriteLine("Profit Percentage: " + profitPercent + "%");
            }
            else if (sellingPrice < costPrice)
            {
                double loss = costPrice - sellingPrice;

                double lossPercent = (loss / costPrice) * 100;

                Console.WriteLine("Loss Occurred");
                Console.WriteLine("Loss Percentage: " + lossPercent + "%");
            }
            // If cost price and selling price are equal
            else
            {
                Console.WriteLine("No Profit No Loss");
            }
        }
    }
}

