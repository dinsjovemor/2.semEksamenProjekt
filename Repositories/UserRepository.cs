using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public void DeleteUser(User user)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            using SqliteCommand command = new SqliteCommand(
                "DELETE FROM User WHERE Username = @username",
                connection);
            command.Parameters.AddWithValue("@username", user.username);
            command.ExecuteNonQuery();
            Debug.WriteLine("User has been deleted");
        }

        public void UpdateUser(User user, string oldUsername)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            using SqliteCommand command = new SqliteCommand(
                "UPDATE User SET Username = @username, Password = @password, Role = @role WHERE Username = @oldUsername",
                connection);
            command.Parameters.AddWithValue("@username", user.username);
            command.Parameters.AddWithValue("@oldUsername", oldUsername);
            command.Parameters.AddWithValue("@password", user.password);
            command.Parameters.AddWithValue("@role", user.role);
            command.ExecuteNonQuery();
            Debug.WriteLine("User has been updated");
        }

        public void CreateUser(string username, string password)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            using SqliteCommand command = new SqliteCommand(
                "INSERT INTO User (Username, Password, Role) VALUES (@username, @password, 'Studerende');",
                connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
            Debug.WriteLine("User has been created");
        }
    }
}
