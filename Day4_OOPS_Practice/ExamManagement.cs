using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Day4_OOPS_Practice
{
    public abstract class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Department Dept { get; set; }

        protected Employee(string id, string name, Department dept)
        {
            ID = id;
            Name = name;
            Dept = dept;
        }
    }

    public class HOD : Employee
    {
        public HOD(string id, string name, Department dept) : base(id, name, dept) { }

        public Exam CreateExam(Subject subject, Semester semester, DateTime date, Room room)
        {
            return new Exam(subject, semester, room, date);
        }
    }

    public class Examinee : Employee
    {
        public Examinee(string id, string name, Department dept) : base(id, name, dept) { }
    }

    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Student(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }

    public class Department { public string Name { get; set; } }
    public class Subject { public string Name { get; set; } }
    public class Room { public string Number { get; set; } }
    public class Semester { public string Name { get; set; } }

    public class Exam
    {
        public Subject Subject { get; set; }
        public Semester Semester { get; set; }
        public Room Room { get; set; }
        public DateTime Date { get; set; }
        public Examinee Invigilator { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public Exam(Subject subject, Semester semester, Room room, DateTime date)
        {
            Subject = subject;
            Semester = semester;
            Room = room;
            Date = date;
        }

        public void RegisterBatch(List<Student> batch)
        {
            Students.AddRange(batch);
        }
    }

    class ExamManagement
    {
        static void Main()
        {
            var dept = new Department { Name = "CS" };
            var room = new Room { Number = "101" };
            var hod = new HOD("H1", "Dr. Smith", dept);
            var invigilator = new Examinee("E1", "Prof. Doe", dept);

            var students = Enumerable.Range(1, 10)
                .Select(i => new Student($"S{i}", $"Student {i}"))
                .ToList();

            var subjects = new List<Subject>
            {
                new Subject { Name = "Data Structures" },
                new Subject { Name = "OS" },
                new Subject { Name = "Algorithms" }
            };

            var semesters = new List<Semester>
            {
                new Semester { Name = "Sem 1" },
                new Semester { Name = "Sem 2" }
            };

            var startDate = DateTime.Today;

            foreach (var sem in semesters)
            {
                Console.WriteLine($"--- {sem.Name} ---");

                foreach (var dayOffset in Enumerable.Range(0, 4))
                {
                    var date = startDate.AddDays(dayOffset);
                    Console.WriteLine($"Date: {date:yyyy-MM-dd}");

                    subjects.ForEach(sub =>
                    {
                        var exam = hod.CreateExam(sub, sem, date, room);
                        exam.Invigilator = invigilator;
                        exam.RegisterBatch(students);

                        Console.WriteLine($"  {exam.Subject.Name} | Students: {exam.Students.Count}");
                    });
                }
            }
            Console.ReadKey();
        }
    }
}
