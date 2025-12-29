using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day6
{
    /// <summary>
    /// Static CLass :A static class is a class that cannot be instantiated, 
    /// meaning you cannot use the new keyword to create an object from it
    /// <remark>In a Static Class, all the members must be static and it can be called in a static class only.
    /// There is no need to create objects for static class, we can directly access the meber functions.
    /// </remark>
    /// </summary>
    public static class GeneralUse
    {
        static GeneralUse()
        {

        }
        public static int GetRollno(int rollno)
        {
            return rollno;
        }
    }
    public class StaticCLass
    {
        public static void Main(String[] args)
        {
            Console.WriteLine(GeneralUse.GetRollno(10));
        }
    }
}
