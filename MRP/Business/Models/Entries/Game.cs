using MRP.Business.Enums;

namespace MRP.Business.Models
{
    internal class Game : MediaEntry
    {
        /*******************************/
        /*          PROPERTIES         */
        /*******************************/

        /// <summary>
        /// Gets or Sets game-specific genres
        /// </summary>
        public HashSet<GameGenre> Genre { get; set; }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Constructor for initializing new Game 
        /// </summary>
        /// <param name="creatorId">UserId of the creator</param>
        public Game(Guid creatorId, string title) : base(creatorId, title)
        {
            Genre = new HashSet<GameGenre>();
        }

        /// <summary>
        /// Constructor for rehydrating from database
        /// </summary>
        internal Game(Guid id, Guid creator, DateTime createdAt, string title,
            string description, DateOnly releaseYear, int ageRestriction, GameGenre[] genres)
            : base(id, creator, createdAt, title, description, releaseYear, ageRestriction)
        {
            Genre = genres.ToHashSet();
        }
    }
}
