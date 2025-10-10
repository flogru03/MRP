using MRP.Business.Enums;
using MRP.Business.Models;

namespace MRP.Business.Models
{
    /// <summary>
    /// Abstract MediaEntry Model
    /// </summary>
    internal abstract class MediaEntry
    {
        /// <summary>
        /// EntryID
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the userId of the creator
        /// </summary>
        public Guid Creator { get; }

        /// <summary>
        /// Gets the date and time when media-entry was created
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets or Sets the title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets the release year
        /// </summary>
        public DateOnly ReleaseYear { get; set; }

        /// <summary>
        /// Gets or Sets the age restriction, defaults to 0
        /// </summary>
        public int AgeRestriction { get; set; } 

        /// <summary>
        /// Constructor for initializing new media-entry
        /// </summary>
        /// <param name="creatorId">UserId of the creator</param>
        /// <param name="title">Title of the media-entry</param>
        protected MediaEntry(Guid creatorId, string title)
        {
            Id = new Guid();
            Creator = creatorId;
            Title = title;
            Description = string.Empty;
            ReleaseYear = new DateOnly();
        }

        /// <summary>
        /// Constructor for rehydrating from database
        /// </summary>

        protected MediaEntry(Guid id, Guid creator, DateTime createdAt, string title,
            string description, DateOnly releaseYear, int ageRestriction)
        {
            Id = id;
            Creator= creator;
            CreatedAt = createdAt;
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            AgeRestriction = ageRestriction;
        }
    }
}
