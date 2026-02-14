using Microsoft.Data.SqlClient;
using System.Data;

class Program
{
    public static void Main(String[] args)
    {
        DotNetEnv.Env.Load();

        string cs = Environment.GetEnvironmentVariable("CONNECTION_STRING");
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";

        using var con = new SqlConnection(cs);
        using var dataAdapter = new SqlDataAdapter(sql, con);

        var table = new DataTable("Employees");
        dataAdapter.Fill(table);

        Console.WriteLine($"Rows loaded: {table.Rows.Count}");
        table.WriteXml("tableXMLData.xml");
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"{row["EmployeeId"]} | {row["FullName"]} | {row["Department"]} | {row["Salary"]}");
        }
    }
}