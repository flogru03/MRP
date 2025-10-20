using MRP.DTO;
using MRP.Services;
using MRP.Server;
using MRP.Business.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MRP.Business;


namespace MRP.Controller
{
    internal class UserController
    {
        public async Task HandleRequestAsync(HttpListenerRequest req, HttpListenerResponse res)
        {
            var path = req.Url!.AbsolutePath.ToLower();
            var method = req.HttpMethod.ToUpper();

            if (path == "/api/users/register" && method == "POST")
            {
                await Register(req, res);
            }
            else if (path == "/api/users/login" && method == "POST")
            {
                await Login(req, res);  
            }
        }
        private async Task Register(HttpListenerRequest req, HttpListenerResponse res)
        {
            try
            {
                var body = await new StreamReader(req.InputStream).ReadToEndAsync();
                var dto = JsonConvert.DeserializeObject<CreateUserDTO>(body);

                _service.CreateUser(dto!);
            }
            catch (UserAlreadyExistsException e)
            {
                Console.WriteLine("Error: User already exists!");
                await RequestRouter.WriteJsonAsync(res, e.Message, (int)HttpStatusCode.Conflict);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Error: Empty DTO!");
                await RequestRouter.WriteJsonAsync(res, e.Message, (int)HttpStatusCode.Conflict);
            }
        }
        private async Task Login(HttpListenerRequest req, HttpListenerResponse res)
        {
            try
            {
                var body = await new StreamReader(req.InputStream).ReadToEndAsync();
                var dto = JsonConvert.DeserializeObject<CreateUserDTO>(body);

                // Check if data is valid
                if (_service.CheckUserData(dto!) == false)
                    throw new ArgumentNullException("Empty Username or Password");

                // Check if password is correct
                if (_service.CheckPassword(dto!) == false)
                    throw new UnauthorizedAccessException("Wrong Password");

                // Generate Token
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Login");
                await RequestRouter.WriteJsonAsync(res, e.Message, (int)HttpStatusCode.Conflict);
            }
        }
        

        public UserController(UserService userService)
        {
            _service = userService;
        }

        private UserService _service;
    }
}
