using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    abstract class DiscountPolicy
    {
        public abstract double GetFinalAmount(double amount);
    }

    class FestivalDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if(amount >= 5000)
            {
                return amount - (amount * 0.10);
            }
            else
            {
                return amount - (amount * 0.05);
            }
        }
    }
    class MemberDiscount : DiscountPolicy
    {
        public override double GetFinalAmount(double amount)
        {
            if (amount >= 2000)
            {
                return amount - 300;
            }
            else
                return amount;
        }
    }
    public class ECommerce_abstraction
    {
        static void Main(String[] args)
        {
            string discountType = "Member";
            double amount = 1500;
            DiscountPolicy policy;
            if(discountType == "Festival")
            {
                policy = new FestivalDiscount();
                double finalAmount = policy.GetFinalAmount(amount);
                Console.WriteLine(finalAmount);
            }
            else if(discountType == "Member")
            {
                policy = new MemberDiscount();
                double finalAmount = policy.GetFinalAmount(amount);
                Console.WriteLine(finalAmount);
            }
        }
    }
}
