using System;
using System.Collections.Generic;
using System.Text;

namespace CapgeminiTraining
{
    /// <summary>
    /// This program implimnets the Private variables concpet. 
    /// </summary>
    class UserDetails
    {
        /// <summary>
        /// This is a private classs variables who cannot be acccessed from outside of it.
        /// </summary>
        private string name;
        private int age;
        private int id;

        /// <summary>
        /// THis function takes user input form Main function and passes it the varibales of this class
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userAge"></param>
        /// <param name="userID"></param>
        public void Take_userDetails(string userName, int userAge, int userID)
        {
            this.name = userName;
            this.age = userAge;
            this.id = userID;
        }

        /// <summary>
        /// This function prints the vlaues of the variables.
        /// </summary>
        public void PrintDetails()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("ID: " + id);
        }
    }

/// <summary>
/// Main Class or Entry Point of the program
/// </summary>
public class MultiClassOOPS
    {
        /// <summary>
        /// Main function of the program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            UserDetails user1 = new UserDetails();
            user1.Take_userDetails("Anshul", 20, 3001);
            user1.PrintDetails();


        }

    }
}
