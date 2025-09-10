using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal abstract class MediaEntry
    {
        protected List<uint> _ratings;
        protected MediaEntry()
        {
            _ratings = new List<uint>();
        }
    }
}
