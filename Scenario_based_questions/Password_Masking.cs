using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class Password_generate
    {
        public string password { get; set; }
        public Password_generate(string pass)
        {
            password = pass;
        }
        public void Pass_Manupilation()
        {
            if(string.IsNullOrEmpty(password) || password.Length < 3)
            {
                Console.WriteLine(password);
                return;
            }
            char[] passArray = password.ToCharArray();
            for(int i = 1; i < passArray.Length - 1; i++)
            {
                passArray[i] = '*';
            }
            string result = new string(passArray);
            Console.WriteLine(result);

        }
    }
    public class Password_Masking
    {
        static void Main(String[] args)
        {
            Password_generate password = new Password_generate("Welcome");
            password.Pass_Manupilation();
        }
    }
}
