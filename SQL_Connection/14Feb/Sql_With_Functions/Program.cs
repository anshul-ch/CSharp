using Microsoft.Data.SqlClient;
using DotNetEnv;

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
        DotEnv.Env.Load();

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
            {
                Functions.ShowDB(connection, sql);
            }
            else if (count == 2)
            {
                Console.WriteLine("Enter id:");
                int id = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter name:");
                string? name = Console.ReadLine();

                Console.WriteLine("Enter age:");
                int age = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Enter grade:");
                string? grade = Console.ReadLine();

                Student obj = new Student
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
                Console.WriteLine("Enter id:");
                int id = int.Parse(Console.ReadLine()!);

                Functions.DeleteIntoDB(connection, deleteSql, id);
            }
            else
            {
                Console.WriteLine("Thank you");
            }
        }
    }
}
>>>>>>> 4f6342a6565def92e1b76eee5600084f8f58f97d
