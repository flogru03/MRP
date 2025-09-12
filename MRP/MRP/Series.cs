using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal class Series : MediaEntry
    {
        public Series(User creator, MediaEntryData data) : base(creator, data)
        {
        }

        protected override Type MediaType => typeof(Series);
    }
}
