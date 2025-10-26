using MySql.Data.MySqlClient;

namespace project
{
    public class Db
    {
        private static string connectionString = "server=localhost;user=root;database=my_project;";
        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
