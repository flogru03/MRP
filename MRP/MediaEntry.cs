using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal struct MediaEntryData
    {
        public List<string> Genre;
        public string Title;
        public string Description;
        public DateOnly ReleaseYear;
        public uint AgeRestriction;

        public MediaEntryData()
        {
            Genre = new List<string>();
            Title = "Empty Title";
            Description = "Empty Description";
            ReleaseYear = new DateOnly();
            AgeRestriction = 0;
        }
        public MediaEntryData
            (
            List<string> genre,
            string title,
            string description,
            DateOnly releaseYear,
            uint ageRestriction
            )
        {
            Genre = genre;
            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            AgeRestriction = ageRestriction;
        }
    }
    internal abstract class MediaEntry
    {
        protected User _creator;
        
        protected MediaEntryData _data;
        protected List<MediaRating> _ratings;

        protected abstract Type MediaType { get; }
        protected MediaEntryData Data { get; }

        protected MediaEntry(User user)
        {
            _creator = user;
            _data = new MediaEntryData();
            _ratings = new List<MediaRating>();
        }
        protected MediaEntry(User user, MediaEntryData data)
        {
            _creator = user;
            _data = data;
            _ratings = new List<MediaRating>();
        }
    }
}
