using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace project
{
    public class Db
    {
        private static string connectionString = "server=localhost;port=3306;user=root;password=2007Vfrcbv/;database=my_project;";

        public static MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        public void Execute<T>(string query, ref List<T> list, Func<MySqlDataReader, T> map)
        {
            list.Clear();
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(query, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read()) list.Add(map(reader));
        }

        public void ExecuteNonQuery(string query)
        {
            using var conn = GetConnection();
            using var cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
        }
    }
}
