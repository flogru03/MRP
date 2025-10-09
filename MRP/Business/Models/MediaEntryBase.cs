using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business.Models
{
    // TODO: refactor this
    internal abstract class MediaEntryBase
    {
        protected User _creator;
        protected List<MediaRating> _ratings;
        public string Title;
        public string Description;
        public DateOnly ReleaseYear;
        public uint AgeRestriction;

        protected MediaEntryBase(User user)
        {
            _creator = user;
            _ratings = new List<MediaRating>();

            Title = "Empty Title";
            Description = "Empty Description";
            ReleaseYear = new DateOnly();
            AgeRestriction = 0;
        }

        protected MediaEntryBase
            (
            User creator,
            List<string> genre,
            string title,
            string description,
            DateOnly releaseYear,
            uint ageRes
            )
        {
            _creator = creator;
            _ratings = new List<MediaRating>();

            Title = title;
            Description = description;
            ReleaseYear = releaseYear;
            AgeRestriction= ageRes;
        }

        
    }
}
