using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day3_OOPS
{
    /// <summary>
    /// Usage of base methods in child class. Usage of base method.
    /// </summary>

    public class AccountDetails
    {
        public int id { get; set; }
        public string name { get; set; }
        

        public string GetBaseDetails()
        {
            return $"I am from base class. Account id {id}";
        }
    }
    public class SalesAccount : AccountDetails
    {
        public string salesInfo { get; set; }
        
        public string GetSalesInfo() 
        {
            string salesinfo = string.Empty ;
            salesinfo += base.GetBaseDetails();  // base: will go to parent,
                                                 // direectly : use if child has it's own use, if not then go to base class
            salesinfo += $" This is of Sales Account. Account Id is {id}";
            return salesinfo ;
        }
    }

    public class Accounts
    {
        public static void Main(String[] args)
        {
            AccountDetails accountDetails = new AccountDetails() { id=12,name = "Anuj"};
            Console.WriteLine(accountDetails.GetBaseDetails());
            SalesAccount sales = new SalesAccount() { id =10, name= "Ajay", salesInfo = "Computer"};
            Console.WriteLine(sales.GetSalesInfo());
        }
    }
}
