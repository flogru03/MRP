using MRP.DTO;
using MRP.Services;
using MRP.Server;
using MRP.Business;
using Newtonsoft.Json;
using System.Net;

namespace MRP.Controller
{
    /// <summary>
    /// Handles User-specific HTTP-requests
    /// </summary>
    internal class UserController
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Routes the path specified in the request to correct handler
        /// </summary>
        /// <param name="req">HTTP-Request</param>
        /// <param name="res">HTTP-Response</param>
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

        /// <summary>
        /// Registers new User
        /// </summary>
        /// <param name="req">HTTP-Request</param>
        /// <param name="res">HTTP-Response</param>
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

        /// <summary>
        /// User-Login
        /// </summary>
        /// <param name="req">HTTP-Request</param>
        /// <param name="res">HTTP-Response</param>
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

                // TODO: Generate Token
                _auth.GenerateToken(dto!.Username);
                await RequestRouter.WriteJsonAsync(res, "Login successful", (int)HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: Login");
                await RequestRouter.WriteJsonAsync(res, e.Message, (int)HttpStatusCode.Conflict);
            }
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Initializes new object of the UserController class
        /// </summary>
        /// <param name="userService">Service for handling User data</param>
        public UserController(UserService userService, AuthenticationService auth)
        {
            _service = userService;
            _auth = auth;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private UserService _service;
        private AuthenticationService _auth;
    }
}
