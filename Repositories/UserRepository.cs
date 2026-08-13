using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.semEksamenProjekt.Repositories
{
    public class UserRepository
    {
        string connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}2.sem projekt.db";
        public User? LoginUser(string username, string password)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            using SqliteCommand command = new SqliteCommand(
                "SELECT * FROM User WHERE Username = @username AND Password = @password",
                connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User
                {
                    username = reader.GetString(0),
                    password = reader.GetString(1),
                    role = reader.GetString(2)
                };

                
                return user;
            }
            return null;
        }
    }
}
