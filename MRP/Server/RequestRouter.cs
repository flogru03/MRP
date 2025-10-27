using MRP.Controller;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MRP.Server
{
    /// <summary>
    /// Delegates http-requests to correct controller
    /// </summary>
    internal class RequestRouter
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        public async void HandleRequestAsync(HttpListenerContext httpContext)
        {
            var req = httpContext.Request;
            var res = httpContext.Response;
        }

        public void AddRoute(string requestData, Action<string> handler)
        {
            Task task = new Task(() => handler(requestData));
        }

        public static async Task WriteJsonAsync(HttpListenerResponse response, object data, int statusCode = 200)
        {

            response.StatusCode = statusCode;
            response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(data);
            var bytes = Encoding.UTF8.GetBytes(json);
            await response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        public RequestRouter()
        {
             _routes = new Dictionary<string, Func<HttpListenerRequest, HttpListenerResponse, Task>>();
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private Dictionary<(string, int), Func<HttpListenerRequest, HttpListenerResponse, Task>> _routes;
    }
}
