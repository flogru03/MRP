using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business
{
    internal class Movie : MediaEntry
    {
        public Movie(User creator) : base(creator)
        {
        }

        public enum Genre
        {
            None = 0,
            Action,
            Western,
            Horror
        }
    }
}
