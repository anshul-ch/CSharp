using System;
using System.Collections.Generic;
using System.Text;


namespace CSharp.Day3_OOPS
{

    public abstract class TaxCalculate
    {
        public string empName { get; set; }
        public int income { get; set; }

        public abstract double CaculateTax();

        public void Display()
        {
            Console.WriteLine("Emp name: " + empName);
            Console.WriteLine("Incone : " + income);
            Console.WriteLine("Tax payed: " + CaculateTax());

        }
    }

    public class IndianTax : TaxCalculate
    {
        public override double CaculateTax()
        {
            return income * 0.20;
        }
    }
    public class UStax : TaxCalculate
    {
        public override double CaculateTax()
        {
            return income * 0.30;
        }
    }

    public class Abstraction
    {
        public static void Main(String[] args)
        {

            TaxCalculate selectedTaxSystem = null;

            Console.WriteLine("Enter 1 for India, 2 for US:");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                selectedTaxSystem = new IndianTax();
            }
            else
            {
                selectedTaxSystem = new UStax();
            }

            Console.Write("Enter Employee Name: ");
            selectedTaxSystem.empName = Console.ReadLine();

            Console.Write("Enter Income: ");
            selectedTaxSystem.income = int.Parse(Console.ReadLine());

            selectedTaxSystem.Display();
        }
    }
}



