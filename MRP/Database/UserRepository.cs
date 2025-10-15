using MRP.Business.Models;  // Model-Classes
using Npgsql;               // PostgeSQL Database Functions

namespace MRP.Database
{
    /// <summary>
    /// Provides function for data operations with user data on the database.
    /// </summary>
    internal class UserRepository : IRepository<User>
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Connects to db, executes query and returns all Users.
        /// </summary>
        /// <returns>All users saved on the database</returns>
        public IEnumerable<User> GetAll()
        {
            // Connection to database
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Execute query for reading all user data
            using var cmd = new NpgsqlCommand(@"SELECT * FROM users", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Reading all data
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var username = reader.GetString(reader.GetOrdinal("username"));
                var password = reader.GetString(reader.GetOrdinal("password"));
                var favoriteEntryIDs = new HashSet<Guid>();

                if (!reader.IsDBNull(reader.GetOrdinal("favoriteEntryIDs")))
                {   // Reading array
                    favoriteEntryIDs = reader.GetFieldValue<Guid[]>(reader.GetOrdinal("favoriteEntryIDs")).ToHashSet();
                }

                // returning users
                yield return new User(id, username, password, favoriteEntryIDs);
            }
        }

        /// <summary>
        /// Connects to db, executes query and deletes user with specified id.
        /// </summary>
        /// <param name="id">Guid of the User</param>
        /// <returns>True on success, False if User doesn't exist</returns>
        public bool DeleteById(Guid id)
        {
            // Return false if user doesn't exist
            if (GetById(id) == null)
                return false;

            // Connection to database
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Execute query for deleting user with specidied id
            using var cmd = new NpgsqlCommand(@"DELETE FROM users WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            return true;
        }

        /// <summary>
        /// Connects to db, executes query and returns desired User.
        /// </summary>
        /// <param name="id">Guid of desired user</param>
        /// <returns>User object, null if no user found</returns>
        public User? GetById(Guid id)
        {
            // Connection to database
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Execute query for reading all user data
            using var cmd = new NpgsqlCommand(@"SELECT * FROM users WHERE id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            { 
                // Reading all data
                var username = reader.GetString(reader.GetOrdinal("username"));
                var password = reader.GetString(reader.GetOrdinal("password"));
                var favoriteEntryIDs = new HashSet<Guid>();

                if (!reader.IsDBNull(reader.GetOrdinal("favoriteEntryIDs")))
                {   // Reading array
                    favoriteEntryIDs = reader.GetFieldValue<Guid[]>(reader.GetOrdinal("favoriteEntryIDs")).ToHashSet();
                }

                // Return new user object
                return new User(id, username, password, favoriteEntryIDs);
            }
            else
            {
                // return null if user with specified id doesn't exist
                return null;
            }
        }

        /// <summary>
        /// Connects to db, executes query and inserts user into database.
        /// </summary>
        /// <param name="entity">Object of the user class</param>
        /// <exception cref="NotImplementedException"></exception>
        public bool Add(User entity)
        {
            // Return false if user already exists
            if (GetById(entity.Id) != null)
                return false;

            // Connection to database
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Build query for adding new User
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO users
                    (id, username, password)
                VALUES 
                    (@id, @username, @passowrd);", 
                conn);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@username", entity.Username);
            cmd.Parameters.AddWithValue("@password", entity.Password);

            // Execute query and close connection
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        /// <summary>
        /// Connects to db, executes query and updates user.
        /// </summary>
        /// <param name="entity">Object of the user class</param>
        /// <exception cref="NotImplementedException"></exception>
        public bool Update(User entity)
        {
            // Return false if user doesn't exist
            if (GetById(entity.Id) == null)
                return false;

            // Connection to database
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Build query for updating existing User
            using var cmd = new NpgsqlCommand(
                @"UPDATE users
                  SET username = @username, 
                      password = @password
                  WHERE
                      id = @id;",
                conn);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@username", entity.Username);
            cmd.Parameters.AddWithValue("@password", entity.Password);

            // Execute query and close connection
            cmd.ExecuteNonQuery();
            conn.Close();
            return true;
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Initializes new object of the UserRepository class
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        public UserRepository(string connectionString)
        {
            _connString = connectionString;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private string _connString;
    }
}
