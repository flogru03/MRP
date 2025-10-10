using MRP.Business.Enums;

namespace MRP.Business.Models
{
    /// <summary>
    /// Series-Model, derives from MediaEntry
    /// </summary>
    internal class Series : MediaEntry
    {
        /*******************************/
        /*          PROPERTIES         */
        /*******************************/

        /// <summary>
        /// Gets or Sets game-specific genres
        /// </summary>
        public HashSet<SeriesGenre> Genre { get; set; }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Constructor for initializing new Series 
        /// </summary>
        /// <param name="creatorId">UserId of the creator</param>
        public Series(Guid creatorId, string title) : base(creatorId, title)
        {
            Genre = new HashSet<SeriesGenre>();
        }

        /// <summary>
        /// Constructor for rehydrating from database
        /// </summary>
        internal Series(Guid id, Guid creator, DateTime createdAt, string title,
            string description, DateOnly releaseYear, int ageRestriction, SeriesGenre[] genres)
            : base(id, creator, createdAt, title, description, releaseYear, ageRestriction)
        {
            Genre = genres.ToHashSet();
        }
    }
}
