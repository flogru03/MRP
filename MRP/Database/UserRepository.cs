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
            using var cmd = new NpgsqlCommand("SELECT * FROM users");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // Reading all data
                var id = reader.GetGuid(reader.GetOrdinal("id"));
                var username = reader.GetString(reader.GetOrdinal("username"));
                var password = reader.GetString(reader.GetOrdinal("password"));
                var favoriteEntryIDs = new List<Guid>();

                if (!reader.IsDBNull(reader.GetOrdinal("favoriteEntryIDs")))
                {   // Reading array
                    favoriteEntryIDs = new List<Guid>(reader.GetFieldValue<Guid[]>(reader.GetOrdinal("favoriteEntryIDs")));
                }

                // returning users
                yield return new User(id, username, password, favoriteEntryIDs);
            }
        }

        /// <summary>
        /// Connects to db, executes query and deletes user with specified id.
        /// </summary>
        /// <param name="id">Guid of the User</param>
        public void DeleteById(Guid id)
        {
            // Return if user doesn't exist
            if (this.GetById(id) != null)
                return;

            // Connection to database
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Execute query for deleting user with specidied id
            using var cmd = new NpgsqlCommand("DELETE FROM users WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
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
            using var cmd = new NpgsqlCommand("SELECT * FROM users WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            { 
                // Reading all data
                var username = reader.GetString(reader.GetOrdinal("username"));
                var password = reader.GetString(reader.GetOrdinal("password"));
                var favoriteEntryIDs = new List<Guid>();

                if (!reader.IsDBNull(reader.GetOrdinal("favoriteEntryIDs")))
                {   // Reading array
                    favoriteEntryIDs = new List<Guid>(reader.GetFieldValue<Guid[]>(reader.GetOrdinal("favoriteEntryIDs")));
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

        // TODO: Implement adding user
        /// <summary>
        /// Connects to db, executes query and inserts user into database.
        /// </summary>
        /// <param name="entity">Object of the user class</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        // TODO: Implement updating User
        /// <summary>
        /// Connects to db, executes query and updates user.
        /// </summary>
        /// <param name="entity">Object of the user class</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(User entity)
        {
            throw new NotImplementedException();
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
