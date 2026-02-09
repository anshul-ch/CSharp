using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class Employee
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Email {get; set;}
        public int Salary { get; set; }

        public Employee(int id, string name, string email, int salary)
        {
            ID = id;
            Name = name;
            if (salary <= 0) 
                Salary = 30000;
            else
            {
                Salary = salary;
            }
            if (!email.Contains("@"))
            {
                Email = "unknown@company.com";
            }
            else
            {
                Email = email;
            }
        }
        public void PrintDetails()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Salary: " + Salary);
        }

    }

    public class Employee_Onboarding
    {
        static void Main(String[] args)
        {
            Employee employee = new Employee(101, "Ansh", "abc@gmail.com", 30000);
            Employee employee2 = new Employee(102, "Ansh", "abc@gmail.com", 0);
            Employee employee3 = new Employee(104, "Ansh", "abcgmail.com", 200);

            employee.PrintDetails();
            employee2.PrintDetails();
            employee3.PrintDetails();
        }
    }
}
