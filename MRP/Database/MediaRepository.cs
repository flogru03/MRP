using MRP.Business.Models;
using Npgsql;

namespace MRP.Database
{
    /// <summary>
    /// Provides function for data operations with media entry data on the database.
    /// </summary>
    internal class MediaRepository : IRepository<MediaEntry>
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Connects to db, executes query and returns all media entries.
        /// </summary>
        /// <returns>All media entries saved on the database</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<MediaEntry> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connects to db, executes query and returns desired media entry.
        /// </summary>
        /// <param name="id">Guid of desired media entry</param>
        /// <returns>Media entry object, null if no media entry found</returns>
        /// <exception cref="NotImplementedException"></exception>
        public MediaEntry? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connects to db, executes query and inserts media entry into database.
        /// </summary>
        /// <param name="entity">Object of a class derived from the MediaEntryBase class</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(MediaEntry entity)
        {
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO media_entries
                    (id, creator, title, description, release_year, age_restriction, genre, type, created_at)
                VALUES 
                    (@id, @creator, @title, @description, @release_year, @age_restriction, @genre, @type, @created_at);",
                conn);

            cmd.Parameters.AddWithValue("@id", entry.Id);
            cmd.Parameters.AddWithValue("@creator", entry.Creator);
            cmd.Parameters.AddWithValue("@title", entry.Title);
            cmd.Parameters.AddWithValue("@description", entry.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@release_year", entry.ReleaseYear.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@age_restriction", entry.AgeRestriction);
            cmd.Parameters.AddWithValue("@genre", entry.Genre);
            cmd.Parameters.AddWithValue("@type", entry.Type.ToString());
            cmd.Parameters.AddWithValue("@created_at", entry.CreatedAt);
        }

        /// <summary>
        /// Connects to db, executes query and updates media entry.
        /// </summary>
        /// <param name="entity">Object of a class derived from the MediaEntryBase class</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(MediaEntry entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connects to db, executes query and deletes media entry with specified id.
        /// </summary>
        /// <param name="id">Guid of the User</param>
        /// <exception cref="NotImplementedException"></exception>
        public void DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Initializes new object of the MediaEntryRepository class
        /// </summary>
        /// <param name="connectionString">Database connection string</param>
        public MediaRepository(string connectionString)
        {
            _connString = connectionString;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private string _connString;
    }
}
