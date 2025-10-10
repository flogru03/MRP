using MRP.DTO;
using MRP.Database;
using MRP.Business.Models;

namespace MRP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(new Guid(), "test");
            var movie = new Movie(new Guid(), "test");

            MediaEntry entry = game;

            if (entry is Game)
            {
            }
        }
    }
}
