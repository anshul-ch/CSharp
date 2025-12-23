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
            IndianTax empIndia = new IndianTax() { empName = "Anuj", income = 1000000 };
            empIndia.CaculateTax();
            UStax empUS = new UStax() { empName = "james", income = 250000 };
            empUS.CaculateTax();
            empUS.Display();
            empIndia.Display();
        }
    }
}



