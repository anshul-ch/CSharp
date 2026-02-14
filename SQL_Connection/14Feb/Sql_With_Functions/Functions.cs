using Microsoft.Data.SqlClient;

namespace Sql_With_Functions
{
    public static class Functions
    {
        public static void ShowDB(SqlConnection con, string sql)
        {
            using var cmd = new SqlCommand(sql, con);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)} | {reader.GetString(1)} | {reader.GetInt32(2)} | {reader.GetString(3)}");
            }
        }

        public static void InsertIntoDB(Student obj, string insertSql, SqlConnection con)
        {
            using var cmd = new SqlCommand(insertSql, con);
            cmd.Parameters.AddWithValue("@id", obj.id);
            cmd.Parameters.AddWithValue("@name", obj.name);
            cmd.Parameters.AddWithValue("@age", obj.age);
            cmd.Parameters.AddWithValue("@grade", obj.grade);

            cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted Successfully");
        }

        public static void DeleteIntoDB(SqlConnection con, string sql, int id)
        {
            using var cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Deleted Successfully");
        }
    }

}