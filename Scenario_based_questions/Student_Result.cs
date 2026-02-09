using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Scenario_based_questions
{
    class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    class Student : Person
    {
        public string Rollno { get; set; }
        public int Marks { get; set; }
        public Student(string roll, int marks, string name, int age) : base(name, age)
        {
            Rollno = roll;
            Marks = marks;
        }
        public void PrintDetails()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Rollno: " + Rollno);
            if (Marks > 35)
            {
                Console.WriteLine("Status : Pass");
            }
            else
            {
                Console.WriteLine("Status: Fail");
            }
        }
    }

    public class Student_Result
    {
        static void Main(String[] args)
        {
            Student student = new Student("A101", 90, "Amit", 15);
            student.PrintDetails();

        }
    }
}
