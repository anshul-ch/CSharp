using System;
using System.Collections.Generic; // Required for List<T>
using System.IO;
using System.Xml.Serialization;

namespace CSharp.Data_Serialization
{
    // 1. The Data Object
    public class Student
    {
        public int RollNo { get; set; }
        public string Name { get; set; }

        // A List will automatically serialize into repeating XML elements
        public List<int> Marks { get; set; }

        // Parameterless constructor (Required)
        public Student()
        {
            Marks = new List<int>(); // Good practice to initialize the list
        }
    }

    class XML_Data
    {
        static void Main(string[] args)
        {
            // 2. Instantiate the object with a list of marks
            Student myStudent = new Student
            {
                RollNo = 101,
                Name = "Jane Doe",
                Marks = new List<int> { 85, 92, 78, 90 }
            };

            // 3. Convert (Serialize) to XML
            string xmlOutput = ObjectToXml(myStudent);

            // 4. Display the result
            Console.WriteLine(xmlOutput);
            Console.ReadKey();
        }

        // Helper method to convert object to XML string
        public static string ObjectToXml<T>(T data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, data);
                return writer.ToString();
            }
        }
    }
}