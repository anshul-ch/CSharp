using System;
using System.Reflection;

namespace CSharp.Additional_Topics
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Salary { get; private set; }

        private string secretCode = "X9Z";

        public Employee() { }

        public Employee(int id, string name, decimal salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void GiveRaise(decimal amount)
        {
            Salary += amount;
        }

        private string GetSecretCode() => secretCode;
    }
    class Reflections_Invoke
    {
        static void Main()
        {
            Employee emp = new Employee(101, "Arun", 45000m);

            Type t = emp.GetType();
            MethodInfo? m = t.GetMethod("GiveRaise");
            MethodInfo? m1 = t.GetMethod("GetSecretCode", BindingFlags.NonPublic | BindingFlags.Instance);
           object? secret =  m1!.Invoke(emp,null);
            m!.Invoke(emp, new object[] { 5000m });
            Console.WriteLine(secret);
            Console.WriteLine(emp.Salary);
        }
    }
}