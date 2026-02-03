namespace CSharp.Week3_OOPS
{
    /// <summary>
    /// Implementing a method function from another clas
    /// </summary>
    public class StudentClassInput
    {
        /// <summary>
        /// Function calls the properties of another class(including methods and variables)
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            StudentClass student1 = new StudentClass();
            student1.name = "Shrey";
            student1.age = 10;
            Console.WriteLine(student1.Print_Details());
        }
    }
}
