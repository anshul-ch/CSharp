using Microsoft.Data.SqlClient;
class Program
{
    static void Main()
    {
        string cs = @"Data Source=.\SQLEXPRESS;Database=TrainingDB;Persist Security Info=True;User ID=sa;Password=1234;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Command Timeout=0";

        string insertSql = @"INSERT INTO dbo.Employees(FullName, Department, Salary)VALUES (@Name, @Dept, @Salary)";

        string selectSql = @"SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees ORDER BY EmployeeId";

        using (var con = new SqlConnection(cs))
        {
            con.Open();

            // ---------------- INSERT ----------------
            using (var insertCmd = new SqlCommand(insertSql, con))
            {
                insertCmd.Parameters.AddWithValue("@Name", "Amit");
                insertCmd.Parameters.AddWithValue("@Dept", "CS");
                insertCmd.Parameters.AddWithValue("@Salary", 45000);

                int rows = insertCmd.ExecuteNonQuery();
                Console.WriteLine($"Inserted Rows: {rows}");
            }

            // ---------------- SELECT ----------------
            using (var selectCmd = new SqlCommand(selectSql, con))
            using (var reader = selectCmd.ExecuteReader())
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
