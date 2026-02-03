namespace CSharp.Week3_OOPS
{
    /// <summary>
    /// This code gives ghe basic functions of a class with member functions and member variables
    /// </summary>
    public class BasicClass
    {
        /// <summary>
        /// these are the member variables, public indicates that they can be used in Main function.
        /// </summary>
        
        int rollno;
        string name;
        int age;

        /// <summary>
        /// This function takes the user input and pass it to the member function
        /// </summary>
        /// <param name="userName"></param>
        void TakeName(string userName)
        {
            this.name = userName;

        }

        /// <summary>
        /// This function prints all the detials provided by the user. 
        /// </summary>
        void PrintDetails()
        {
            Console.WriteLine("Name: "+name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Rollno: " + rollno);

        }

        /// <summary>
        /// Main function of the program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            BasicClass student1 = new BasicClass();
            student1.TakeName("anshul");
            student1.rollno = 1;
            student1.age = 18;
            student1.PrintDetails();
        }
    }
}
