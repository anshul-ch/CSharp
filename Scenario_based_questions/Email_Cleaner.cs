using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class Cleaner_Email
    {
        public string Email { get; set; }
        public Cleaner_Email(string mail)
        {
            Email = mail;
        }
        public string EmailCleaning()
        {
            string domain = Email.Trim().ToLower();
            //int Indexat = domain.IndexOf("@");
            //string firstPart = domain.Substring(, Indexat);
            //string domainPart = domain.Substring(Indexat+1);
            //if(domainPart == "gmail.com")
            //{
            //    domainPart = "company.com";
            //}
            //string result = firstPart +"@" +domainPart;
            // alternate method
            if (domain.Contains("@gmail.com"))
            {
                domain = domain.Replace("@gmail.com", "@company.com");
            }
            return domain;
        }
    }
    public class Email_Cleaner
    {
        static void Main(String[] args)
        {
            Cleaner_Email cleaner_ = new Cleaner_Email("    abc@gmail.com  ");
            string result = cleaner_.EmailCleaning();
            Console.WriteLine(result);
        }
    }
}
