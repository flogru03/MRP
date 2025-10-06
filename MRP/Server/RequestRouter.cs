using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using MRP.Services;

namespace MRP.Server
{
    public class RequestRouter
    {
        private readonly UserService _userService = new();

        public async Task HandleRequest(HttpListenerContext context)
        {
            try
            {
                var request = context.Request;
                var response = context.Response;
                string path = request.Url!.AbsolutePath;
                string method = request.HttpMethod;

                Console.WriteLine($"[{method}] {path}");

                if (path == "/api/users/register" && method == "POST")
                {
                    // await _userService.Register(request, response);
                }
                else if (path == "/api/users/login" && method == "POST")
                {
                    // await _userService.Login(request, response);
                }
                else
                {
                    response.StatusCode = 404;
                    await WriteResponse(response, new { error = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }

        private async Task WriteResponse(HttpListenerResponse response, object body)
        {
            response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(body);
            var buffer = Encoding.UTF8.GetBytes(json);
            await response.OutputStream.WriteAsync(buffer);
            response.Close();
        }
    }
}

