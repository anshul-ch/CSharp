using Microsoft.Data.SqlClient;
class Program
{
    static void Main()
    {
        string cs = @"Data Source=.\SQLEXPRESS;Database=TrainingDB;Persist Security Info=True;User ID=sa;Password=1234;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Command Timeout=0";
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";
        string insetSql = "Insert into dbo.Employee Values(101,'Amit', 'CS',45000)";
        using (var con = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, con))
        {
            con.Open();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string dept = reader.GetString(2);
                    decimal salary = reader.GetDecimal(3);

                    Console.WriteLine($"{id} | {name} | {dept} | {salary}");
                }
            }
        }
    }
}

