using Microsoft.Data.SqlClient;
using DotNetEnv;

namespace Sql_With_Functions
{
    public class Student
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? grade { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Env.Load();

            string cs = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;
            string sql = "SELECT id, name, age, grade FROM dbo.student";
            string insertSql = "INSERT INTO student(id,name,age,grade) VALUES(@id,@name,@age,@grade)";
            string deleteSql = "DELETE FROM student WHERE id=@id";

            using var connection = new SqlConnection(cs);
            connection.Open();

            int count = 0;

            while (count != 4)
            {
                Console.WriteLine("1 -> Show Database\n2 -> Insert\n3 -> Delete\n4 -> Exit");
                count = int.Parse(Console.ReadLine()!);

                if (count == 1)
                    Functions.ShowDB(connection, sql);

                else if (count == 2)
                {
                    Console.Write("Enter id: ");
                    int id = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter name: ");
                    string? name = Console.ReadLine();

                    Console.Write("Enter age: ");
                    int age = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter grade: ");
                    string? grade = Console.ReadLine();

                    var obj = new Student
                    {
                        id = id,
                        name = name,
                        age = age,
                        grade = grade
                    };

                    Functions.InsertIntoDB(obj, insertSql, connection);
                }

                else if (count == 3)
                {
                    Console.Write("Enter id: ");
                    int id = int.Parse(Console.ReadLine()!);
                    Functions.DeleteIntoDB(connection, deleteSql, id);
                }

                else
                    Console.WriteLine("Thank you");
            }
        }
    }
}