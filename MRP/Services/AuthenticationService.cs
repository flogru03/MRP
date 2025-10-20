using MRP.Server;
using System.Net;

namespace MRP.Services
{
    internal class AuthenticationService
    {
        public string GenerateToken(string username)
        {

        }
        public bool IsTokenValid(string token)
        {

        }
        public bool Authorize(HttpListenerRequest req, HttpListenerResponse res)
        {

        }
        public AuthenticationService()
        {
            _token = new Dictionary<string, string>();
        }

        private Dictionary<string, string> _token;
    }
}
