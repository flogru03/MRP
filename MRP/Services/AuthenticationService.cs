using MRP.Server;
using System.Net;

namespace MRP.Services
{
    internal class AuthenticationService
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        public string GenerateToken(string username)
        {
            var token = $"{username}-mrpToken";
            _token[username] = token;
            return token;
        }
        public bool IsTokenValid(string token)
        {

        }
        public bool Authorize(HttpListenerRequest req, HttpListenerResponse res)
        {

        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        public AuthenticationService()
        {

        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private readonly static Dictionary<string, string> _token = new();
    }
}
