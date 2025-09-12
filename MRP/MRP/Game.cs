using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP
{
    internal class Game : MediaEntry
    {
        public Game(User creator) : base(creator)
        {
           
        }

        protected override Type MediaType => typeof(Game);
    }
}
