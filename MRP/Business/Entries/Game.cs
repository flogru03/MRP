using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business
{
    internal class Game : MediaEntry
    {
        public Game(User creator) : base(creator)
        {
           
        }

        public enum Genre
        {
            None = 0,
            FPS,
            RPG,
            Racing
        }
    }
}
