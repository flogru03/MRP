using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal class MediaRating
    {
        private MediaEntry _entry;
        public uint Value
        {
            get { return Value; }
            set { Value = (value < 0 || value > 5) ? value : throw new Exception("Value out of Bounds"); }
        }
        public MediaRating(MediaEntry entry)
        {
            Value = 0;
            _entry = entry;
        }
    }
}
