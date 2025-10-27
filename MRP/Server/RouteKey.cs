using System.Net;

namespace MRP.Server
{
    internal class RouteKey
    {
        public string HTTPMethod { get; init; } = string.Empty;
        public string HTTPPathPattern { get; init; } = string.Empty;

        public static bool Matches(RouteKey key, HttpListenerRequest req)
        {
            if (req == null)
                return false;


            throw new NotImplementedException();    
        }
        
        public RouteKey(string method, string routePattern)
        {
            HTTPMethod = method;
            HTTPPathPattern = routePattern;
        }
    }
}
