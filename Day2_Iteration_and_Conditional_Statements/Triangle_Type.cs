using System;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// Determine the type of triangles based on sides on a triangle
    /// </summary>
    public class Triangle_Type
    {
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter 1st Side of Triangle: ");
            int side1 = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Enter 2nd Side of Triangle: ");
            int side2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter 3rd Side of Triangle: ");
            int side3 = int.Parse(Console.ReadLine());

            if (side1 == side2 && side2 == side3)
            {
                Console.WriteLine("Equilateral Triangle!");
            }
  
            else if (side1 != side2 && side2 != side3 && side3 != side1)
            {
                Console.WriteLine("Scalene Triangle!");
            }
            
            else
            {
                Console.WriteLine("Isosceles Triangle!");
            }
        }
    }
}
