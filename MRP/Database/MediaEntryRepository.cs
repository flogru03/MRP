using MRP.Business.Models;
using Npgsql;

namespace MRP.Database
{
    /// <summary>
    /// Provides function for data operations with media entry data on the database.
    /// </summary>
    internal class MediaEntryRepository : IRepository<MediaEntryBase>
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Connects to db, executes query and returns all media entries.
        /// </summary>
        /// <returns>All media entries saved on the database</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<MediaEntryBase> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connects to db, executes query and returns desired media entry.
        /// </summary>
        /// <param name="id">Guid of desired media entry</param>
        /// <returns>Media entry object, null if no media entry found</returns>
        /// <exception cref="NotImplementedException"></exception>
        public MediaEntryBase? GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connects to db, executes query and inserts media entry into database.
        /// </summary>
        /// <param name="entity">Object of a class derived from the MediaEntryBase class</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(MediaEntryBase entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Connects to db, executes query and updates media entry.
        /// </summary>
        /// <param name="entity">Object of a class derived from the MediaEntryBase class</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(MediaEntryBase entity)
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
        public MediaEntryRepository(string connectionString)
        {
            _connString = connectionString;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private string _connString;
    }
}
