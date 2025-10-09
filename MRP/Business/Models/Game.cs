using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business.Models
{
    internal class Game : MediaEntryBase
    {
        public Game(User creator) : base(creator)
        {
           
        }

        // TODO: add global genre enum

        public enum Genre
        {
            None = 0,
            FPS,
            RPG,
            Racing
        }
    }
}
