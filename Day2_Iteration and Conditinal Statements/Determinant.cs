using System;

namespace CSharp.Day2_Iteration_and_Conditional_Statements
{
    /// <summary>
    /// This program finds the quadratic roots based on discriminant
    /// </summary>
    public class Determinant
    {
        /// <summary>
        /// This method calculates and prints quadratic roots
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Quad_Roots(double a, double b, double c)
        {
            double determinant = b * b - 4 * a * c;

            if (determinant < 0)
            {
                Console.WriteLine("No real roots exist");
            }
            else if (determinant == 0)
            {
                double root = -b / (2 * a);
                Console.WriteLine("One real root exists:");
                Console.WriteLine("Root = " + root);
            }
            else
            {
                double root1 = (-b + Math.Sqrt(determinant)) / (2 * a);
                double root2 = (-b - Math.Sqrt(determinant)) / (2 * a);
                Console.WriteLine("Two real roots exist:");
                Console.WriteLine("Root 1 = " + root1);
                Console.WriteLine("Root 2 = " + root2);
            }
        }

        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.Write("Enter a: ");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter c: ");
            double c = Convert.ToDouble(Console.ReadLine());

            Determinant obj = new Determinant();
            obj.Quad_Roots(a, b, c);
        }
    }
}
