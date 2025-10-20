using System.Text;
using System.Net;
using Newtonsoft.Json;
using MRP.Controller;

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

        /// <summary>
        /// Aanalyses path and calls corresponding handler
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task HandleRequest(HttpListenerContext context)
        {
            try
            {
                var request = context.Request;
                var response = context.Response;

                string path = request.Url!.AbsolutePath.ToLower();
                string method = request.HttpMethod.ToUpper();

                Console.WriteLine($"[{method}] {path}");

                switch (path)
                {
                    case "/api/user":
                        await _userController.HandleRequestAsync(request, response);
                        break;
                    case "/api/media":
                        break;
                    case "/api/ratings":
                        break;
                    case "/api/leaderboard":
                        break;
                    default:
                        await WriteJsonAsync(response, $"Error: {path}: invalid path", 404);
                        break;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehler: {e.Message}");
            }
        }

        /// <summary>
        /// Writes Http-response
        /// </summary>
        /// <param name="response"></param>
        /// <param name="data"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Initializes new Instance of the RequestRouter-class
        /// </summary>
        /// <param name="userCon">User Controller</param>
        /// <param name="mediaCon">Media Controller</param>
        /// <param name="ratingCon">Rating Controller</param>
        public RequestRouter(UserController userCon, MediaController mediaCon, RatingController ratingCon)
        {
            _userController = userCon;
            _mediaController = mediaCon;
            _ratingController = ratingCon;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private UserController _userController;
        private MediaController _mediaController;
        private RatingController _ratingController;
    }
}

