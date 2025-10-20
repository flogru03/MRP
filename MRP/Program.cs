using MRP.Server;

namespace MRP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer("http://localhost:8080/api/");
            server.Start();
        }
    }
}
