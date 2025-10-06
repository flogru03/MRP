using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business                  
{
    internal class User
    {
        private readonly string _username;
        private readonly string _password;
        private List<MediaRating> _ratings;
        private List<MediaEntry> _entries;
        private List<MediaEntry> _favorites;

        public string Username 
        { 
            get => _username; 
        }
        public uint NumRatings 
        {
            get => (uint) _ratings.Count;
        }
        public uint CommonRating 
        {
            get
            {
                uint total = 0;
                foreach (var rating in _ratings)
                {
                    total += rating.Value;
                }
                return total > 0 ? (uint) _ratings.Count / total : 0;
            }
        }

        public User(string username, string password)
        {
            _username = username;
            _password = password;
            _ratings = new List<MediaRating>();
            _entries = new List<MediaEntry>();
            _favorites = new List<MediaEntry>();
        }
    }
}
