using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day3_OOPS
{
    /// <summary>
    /// This program implements the use of Virtual and Override for method overriding
    /// </summary>

    public class MethodOverride
    {
        public virtual string GetInfo()            // virtual allow you to overide the function
        {
            return "I like to play cricket";
        }
    }
    public class MethodOverride2 : MethodOverride 
    {
        public override string GetInfo()             // override actually override the function
        {
            return "I like to play PC games";
        }
    }
    public class Virtual
    {
        public static void Main(string[] args)
        {
            MethodOverride2 override1 = new MethodOverride2();
            Console.WriteLine(override1.GetInfo());
            
        }
    }
}
