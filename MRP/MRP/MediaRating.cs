using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal struct MediaRatingData
    {
        public uint Value;
        public string Comment;

        public MediaRatingData()
        {
            Value = 0;
            Comment = string.Empty;
        }
        public MediaRatingData(uint value, string comment)
        {
            Value = value; 
            Comment = comment;
        }
    }
    internal class MediaRating
    {
        private User _creator;
        private MediaEntry _entry;

        private MediaRatingData _data;
        private DateTime _timestamp;
        private uint _likes;
        private bool _isPublic;
        public uint Value
        {
            get 
            { 
                return _data.Value; 
            }
            set 
            {
                _data.Value = (value < 0 || value > 5) ? value : throw new Exception("Value out of Bounds"); 
            }
        }
        public MediaRating(MediaEntry entry, User user)
        {
            _data = new MediaRatingData();
            _entry = entry;
            _creator = user;
        }
    }
}
