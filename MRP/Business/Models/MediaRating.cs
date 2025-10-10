using MRP.Business.Enums;

namespace MRP.Business.Models
{
    /// <summary>
    /// MediaRating Model
    /// </summary>
    internal class MediaRating
    {
        /*******************************/
        /*          PROPERTIES         */
        /*******************************/

        /// <summary>
        /// RatingID
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the userId of the creator
        /// </summary>
        public Guid Creator { get; }

        /// <summary>
        /// Gets the date and time when rating was created
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the entryId of the rated media-entry
        /// </summary>
        public Guid Entry { get; }

        /// <summary>
        /// Gets the state of the star-rating
        /// </summary>
        public StarRating Stars { get; set; }

        /// <summary>
        /// Gets or Sets the comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets or Sets the publicity-state
        /// </summary>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets the count of likes
        /// </summary>
        public int Likes { get => _userIdsWhichLiked.Count; }

        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Increments like-count by one
        /// </summary>
        /// <remarks>
        /// One user can only like once
        /// </remarks>
        /// <param name="userId">UserId of user which gave like</param>
        public void LikeFrom(Guid userId)
        {
            if (_userIdsWhichLiked.Contains(userId) == false)
            {
                _userIdsWhichLiked.Add(userId);
            }
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Constructor for initializing new ratings
        /// </summary>
        /// <param name="creatorId">UserId of the creator</param>
        /// <param name="entryId">EntryId of the rated media-entry</param>
        public MediaRating(Guid creatorId, Guid entryId)
        {
            Id = new Guid();
            Creator = creatorId;
            CreatedAt = DateTime.Now;
            Entry = entryId;
            Stars = StarRating.None;
            IsPublic = false;
            Comment = string.Empty;
            _userIdsWhichLiked = new HashSet<Guid>();
        }

        /// <summary>
        /// Constructor for rehydrating from database
        /// </summary>
        internal MediaRating(Guid id, Guid creator, DateTime createdAt, Guid entry, 
            int stars, bool isPublic, string comment, Guid[] userIdsWhichLiked)
        {
            Id = id;
            Creator = creator;
            CreatedAt = createdAt;
            Entry = entry;
            Stars = (StarRating)stars;
            IsPublic = isPublic;
            Comment = comment;
            _userIdsWhichLiked = new HashSet<Guid>(userIdsWhichLiked);
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private HashSet<Guid> _userIdsWhichLiked;
    }
}
