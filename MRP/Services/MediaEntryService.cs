using MRP.Business;
using MRP.Business.Models;
using MRP.Database;

namespace MRP.Services
{
    /// <summary>
    /// Provides Methods for manipulating MediaEntry data
    /// </summary>
    internal class MediaEntryService
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Connects to database and selects all MediaEntry data
        /// </summary>
        /// <typeparam name="T">Type of MediaEntry</typeparam>
        /// <returns>All MediaEntry data as objects</returns>
        /// <exception cref="NotImplementedException"></exception>
        public MediaEntry CreateMediaEntry<T>() where T : MediaEntry
        {
            throw new NotImplementedException();
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Initializes new MediaEntryService object
        /// </summary>
        /// <param name="mediaEntryRepo">Repository which handles all MediaEntry data</param>
        public MediaEntryService(MediaRepository mediaEntryRepo)
        { 
            _mediaRepo = mediaEntryRepo;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private MediaRepository _mediaRepo;
    }
}
