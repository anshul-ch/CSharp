namespace CSharp.Week3_OOPS
{
    /// <summary>
    /// Class to be implemeted in another class file
    /// </summary>
    public class StudentClass
    {

        /// <summary>
        /// properties of this class that can be used in another class file.
        /// </summary>
        public int age;
        public string name;

        public StudentClass()
        {
            name = string.Empty;
            age = 0;
        }
        public string Print_Details()
        {
            return ("Name: " + name + " Age: " + age);
        }
    }

}
