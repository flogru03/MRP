using System.Net;

namespace MRP.Server
{
    internal class RouteKey
    {
        /// <summary>
        /// e.g. "GET", "POST,...
        /// </summary>
        public string HTTPMethod { get; }

        /// <summary>
        /// e.g. "/api/users/{userid}/favorites
        /// </summary>
        public string HTTPPathPattern { get; }

        /// <summary>
        /// Tests if routekey matches with http request route and parses parameters in the path
        /// </summary>
        /// <param name="req"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static bool Matches(RouteKey key, HttpListenerRequest req, out Dictionary<string, string> parameters)
        {
            parameters = new Dictionary<string, string>();
            
            if (string.Equals(key.HTTPMethod, req.HttpMethod, StringComparison.OrdinalIgnoreCase))
                return false;

            var requestSegments = req.Url!.AbsolutePath.Trim('/').Split('/');
            var patternSegments = key.HTTPPathPattern.Split('/');

            if (requestSegments.Length != patternSegments.Length)
                return false;

            // checks each segments 
            // safes given route parameters in dictionary
            for (int i = 0; i < patternSegments.Length; i++)
            {
                var p = patternSegments[i];
                var r = requestSegments[i];

                if (p.StartsWith("{") && p.EndsWith("}"))
                {
                    var name = p[1..^1];
                    parameters[name] = r;
                }
                else if (!string.Equals(p, r, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            throw new NotImplementedException();    
        }
        
        public RouteKey(string method, string routePattern)
        {
            HTTPMethod = method;
            HTTPPathPattern = routePattern;
        }
    }
}
