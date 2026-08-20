using Microsoft.Data.Sqlite;
using System.Diagnostics;

namespace _2.semEksamenProjekt
{
    public class UserRepository
    {
        string connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}2.sem projekt.db";
        // finder en bruger på brugernavn og adgangskode
        public User GetUserByCredentials(string username, string password)
        {
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            using SqliteCommand command = new SqliteCommand("SELECT Username, Password, Role FROM User WHERE Username = @username AND Password = @password", connection);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            using SqliteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new User
                {
                    username = reader.GetString(0),
                    password = reader.GetString(1),
                    role = reader.GetString(2)
                };
            }

            return null;
        }
        public List<User> GetUsersByRole(string role)
        {
            // samme som GetAllUsers men med WHERE Role = @role
            using SqliteConnection connection = new SqliteConnection(connectionString);
            connection.Open();

            using SqliteCommand command = new SqliteCommand("SELECT Username, Password, Role FROM User WHERE Role = @role", connection);

            command.Parameters.AddWithValue("@role", role);

            using SqliteDataReader reader = command.ExecuteReader();
            List<User> users = new List<User>();
            while (reader.Read())
            {
                users.Add(new User
                {
                    username = reader.GetString(0),
                    password = reader.IsDBNull(1) ? null : reader.GetString(1),
                    role = reader.IsDBNull(2) ? null : reader.GetString(2)
                });
            }
            return users;
        }

        /// <summary>
        /// Lavet af Dina
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Lavet af Dina
        /// </summary>
        /// <param name="user"></param>
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

        /// <summary>
        /// Lavet af Dina
        /// </summary>
        /// <param name="user"></param>
        /// <param name="oldUsername"></param>
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


        /// <summary>
        /// Lavet af Dina
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
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
