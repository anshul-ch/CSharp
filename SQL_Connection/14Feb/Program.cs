using Microsoft.Data.SqlClient;
using System;
using DotNetEnv;

class Program
{
    public static void Main(String[] args)
    {
        
        DotNetEnv.Env.Load();
        string cs = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        Console.Write("Enter Department (e.g., IT): ");
        string dept = Console.ReadLine() ?? "";

        string sql = @"SELECT EmployeeId, FullName, Salary
               FROM dbo.Employees Where Department = @dept
               ORDER BY Salary DESC";
        using var con = new SqlConnection(cs);
        using var cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@dept", dept);

        con.Open();
        using var r = cmd.ExecuteReader();
        while (r.Read())
        {
            Console.WriteLine($"{r["EmployeeId"]} | {r["FullName"]} | {r["Salary"]}");
        }
    }
}