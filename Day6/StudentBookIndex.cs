using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Day6
{
    /// <summary>
    /// Represents a student with identifying information and a collection of books.
    /// </summary>
    /// <remarks>The Student class provides properties for storing the student's name, roll number, and
    /// address details. It also includes an indexer for accessing up to five books associated with the student by
    /// index.</remarks>
    public class Student
    {
        public string Name { get; set; }
        public int RollNo { get; set; }
        private string Address { get; set; }
        private string[] Books = new string[5];
        public string this[int index]
        {
            get { return Books[index]; }
            set { Books[index] = value; }
        }
        public string AddressDetails
        {
            get { return Address; }
            set { Address = value; }
        }
    }
    public class StudentBookIndex
    {
        public static void Main(String[] args)
        {
            Student student = new Student();
            student.Name = "John Doe";
            student.RollNo = 101;
            student.AddressDetails = "123 Main St, Anytown, USA";
            student[0] = "C# Programming";
            student[1] = "Data Structures";
            student[2] = "Algorithms";
            Console.WriteLine($"Student Name: {student.Name}");
            Console.WriteLine($"Roll No: {student.RollNo}");
            Console.WriteLine($"Address: {student.AddressDetails}");
            Console.WriteLine("Books he have: ");
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine(student[i]);
            }
        }
    }
}
