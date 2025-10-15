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
        public void Add<T>(MediaEntry entity)
        {
            // Connect to Database
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            // Build and execute query for adding new MediaEntry
            using var cmd = new NpgsqlCommand(
                @"INSERT INTO media_entries
                    (id, creator, title, description, release_year, age_restriction, genre, type, created_at)
                VALUES 
                    (@id, @creator, @title, @description, @release_year, @age_restriction, @genre, @type, @created_at);",
                conn);

            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@creator", entity.Creator);
            cmd.Parameters.AddWithValue("@title", entity.Title);
            cmd.Parameters.AddWithValue("@description", entity.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@release_year", entity.ReleaseYear.ToDateTime(TimeOnly.MinValue));
            cmd.Parameters.AddWithValue("@age_restriction", entity.AgeRestriction);
            // TODO: Add List of Genres in generic way
            // cmd.Parameters.AddWithValue("@genre", entity.Genre);
            // TODO: T -> Type
            cmd.Parameters.AddWithValue("@type", nameof(entity).ToString());
            cmd.Parameters.AddWithValue("@created_at", entity.CreatedAt);
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

        public bool Add(MediaEntry entity)
        {
            throw new NotImplementedException();
        }

        bool IRepository<MediaEntry>.Update(MediaEntry entity)
        {
            throw new NotImplementedException();
        }

        bool IRepository<MediaEntry>.DeleteById(Guid id)
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
