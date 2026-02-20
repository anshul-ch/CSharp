using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class Program
{
    public static void ShowTable(SqlConnection connection)
    {
        string? query = "SELECT id,name,age,grade FROM dbo.student";
        SqlCommand command = new(query, connection);
        using SqlDataReader sqlDataReader = command.ExecuteReader();
        while (sqlDataReader.Read())
        {
            System.Console.WriteLine(
                $"Id: {sqlDataReader["id"]} Name: {sqlDataReader["name"]} Age: {sqlDataReader["age"]} Grade: {sqlDataReader["grade"]}");
        }

        System.Console.WriteLine();

    }

    public static void DeleteRow(SqlConnection connection)
    {
        System.Console.WriteLine("Enter ID: ");
        int Id = int.Parse(Console.ReadLine()!);

        string? query = "DELETE FROM student WHERE id=@id";
        SqlCommand sqlCommand = new(query, connection);
        sqlCommand.Parameters.AddWithValue("@id", Id);
        int result = sqlCommand.ExecuteNonQuery();
        string? output = result == 0 ? "Failed" : "Success";
        System.Console.WriteLine(output);
    }

    public static void InsertRow(SqlConnection connection)
    {
        System.Console.WriteLine("Enter ID: ");
        int id = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter Name: ");
        string? name = Console.ReadLine();
        System.Console.WriteLine("Enter Age: ");
        int age = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter Grade: ");
        string? Grade = Console.ReadLine();

        string query = " Insert into student(id,name,age,grade) Values(@id,@name, @age,@grade)";
        SqlCommand sqlCommand = new(query, connection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        sqlCommand.Parameters.AddWithValue("@name", name);
        sqlCommand.Parameters.AddWithValue("@age", age);
        sqlCommand.Parameters.AddWithValue("@Grade", Grade);

        int result = sqlCommand.ExecuteNonQuery();
        string? output = result == 0 ? "Failed" : "Success";
        System.Console.WriteLine(output);
    }

    public static void UpdateGrade(SqlConnection connection)
    {
        System.Console.WriteLine("Enter ID: ");
        int id = int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter Grade: ");
        string? grade = Console.ReadLine();

        string? query = "UPDATE student SET grade=@grade WHERE id=@id";
        SqlCommand sqlCommand = new(query, connection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        sqlCommand.Parameters.AddWithValue("@grade", grade);

        int result = sqlCommand.ExecuteNonQuery();
        string? output = result == 0 ? "Failed" : "Success";
        System.Console.WriteLine(output);
    }
    public static void Main(string[] args)
    {
        DotNetEnv.Env.Load();
        string? connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        if (connection.State == ConnectionState.Open) System.Console.WriteLine("We are Live!");

        int choice = 0;
        while (choice < 5)
        {
            System.Console.WriteLine("1 :Show the Table");
            System.Console.WriteLine("2 : Delete a Row ");
            System.Console.WriteLine("3 : Insert a Row ");
            System.Console.WriteLine("4 : Update the Grade");
            System.Console.WriteLine("5 :Exit");

            choice = int.Parse(Console.ReadLine()!);
            if (choice == 1)
            {
                ShowTable(connection);
            }
            else if (choice == 2)
            {
                DeleteRow(connection);
            }
            else if (choice == 3)
            {
                InsertRow(connection);
            }
            else if (choice == 4)
            {
                UpdateGrade(connection);
            }
            else
            {
                System.Console.WriteLine("Thank You !");
            }
        }

    }
}
