using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using MRP.Services;
using MRP.Controller;

namespace MRP.Server
{
    internal class RequestRouter
    {
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
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
        public static async Task WriteJsonAsync(HttpListenerResponse response, object data, int statusCode = 200)
        {
            response.StatusCode = statusCode;
            response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(data);
            var bytes = Encoding.UTF8.GetBytes(json);
            await response.OutputStream.WriteAsync(bytes, 0, bytes.Length);
        }
        public RequestRouter(UserController userCon, MediaController mediaCon, RatingController ratingCon)
        {
            _userController = userCon;
            _mediaController = mediaCon;
            _ratingController = ratingCon;
        }

        private UserController _userController;
        private MediaController _mediaController;
        private RatingController _ratingController;
    }
}

