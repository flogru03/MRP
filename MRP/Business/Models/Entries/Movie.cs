using MRP.Business.Enums;

namespace MRP.Business.Models
{
    internal class Movie : MediaEntry
    {
        /*******************************/
        /*          PROPERTIES         */
        /*******************************/

        /// <summary>
        /// Gets or Sets movie-specific genres
        /// </summary>
        public HashSet<MovieGenre> Genre { get; set; }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Constructor for initializing new Movie
        /// </summary>
        /// <param name="creatorId">UserId of the creator</param>
        public Movie(Guid creatorId, string title) : base(creatorId, title)
        {
            Genre = new HashSet<MovieGenre>();
        }

        /// <summary>
        /// Constructor for rehydrating from database
        /// </summary>
        internal Movie(Guid id, Guid creator, DateTime createdAt, string title,
            string description, DateOnly releaseYear, int ageRestriction, MovieGenre[] genres)
            : base(id, creator, createdAt, title, description, releaseYear, ageRestriction)
        {
            Genre = genres.ToHashSet();
        }
    }
}
