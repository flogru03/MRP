using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal class Movie : MediaEntry
    {
        public Movie(User creator, MediaEntryData data) : base(creator, data)
        {
        }

        protected override Type MediaType => typeof(Movie);
    }
}
