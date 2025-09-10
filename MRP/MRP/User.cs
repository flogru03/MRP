using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal class User
    {
        private readonly string _id;
        private readonly string _password;

        private List<MediaRating> _ratings;
        private List<MediaEntry> _entries;
        private List<MediaEntry> _favorites;

        public string Username { get; private set; }
        public uint NumRatings {
            get => (uint) _ratings.Count;
            private set { }
        }
        public uint CommonRating { get; private set; }
        public string Genre { get; private set; }

        public User() { }
    }
}
