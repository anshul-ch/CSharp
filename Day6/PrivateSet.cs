using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day6
{
    public class Information
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; }
        public Information(string address)
        {
            Address = address;
        }
        public void SetId(int id)
        {
            Id = id;
        }
    }
    public class PrivateSet
    {
        public static void Main(String[] args)
        {
            Information information = new Information("Delhi"); // to set value without a set property
            information.SetId(1);             // to set value in private set

            Console.WriteLine(information.Id);
            Console.WriteLine(information.Address);
        }
    }
}
