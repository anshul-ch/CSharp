using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class Cab
    {

        public virtual decimal CalculateFare(int km)
        {
            return 0;
        }
    }
    class Mini: Cab
    {
        public override decimal CalculateFare(int km)
        {
            return km * 12;
        }
    }
    class Sedan: Cab
    {
        public override decimal CalculateFare(int km)
        {
            return km * 15 + 50;
        }
    }
    class SUV: Cab
    {
        public override decimal CalculateFare(int km)
        {
            return km * 18 + 100;
        }
    }
    public class CabFare_Polymorphism
    {
        static void Main(String[] args)
        {
            string Cabtype = "Sedan";
            int km = 30;
            Cab cab;

            if(Cabtype == "Mini")
            {
                cab = new Mini();
            }
            else if(Cabtype == "Sedan")
            {
                cab = new Sedan();
            }
            else
            {
                cab = new SUV();
            }

            decimal result = cab.CalculateFare(km);
            Console.WriteLine(result);
        }
    }
}
