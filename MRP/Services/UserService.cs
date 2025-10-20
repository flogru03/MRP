using MRP.Business;
using MRP.Business.Models;
using MRP.Database;
using MRP.DTO;

namespace MRP.Services
{
    /// <summary>
    /// Provides methods for manipulation user data
    /// </summary>
    internal class UserService
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Initializes new object of the User class and saves it on the database
        /// </summary>
        /// <param name="dto">DTO for intializing new User objects</param>
        /// <returns>Object of the User created</returns>
        /// <exception cref="ArgumentNullException">If credentials are invalid</exception>
        /// <exception cref="UserAlreadyExistsException">If User already exists</exception>
        public void CreateUser(CreateUserDTO dto)
        {
            // Check if data is valid
            if (CheckUserData(dto) == false)
                throw new ArgumentNullException("Empty Username or Password");

            // Check if User already exists
            if (_userRepo.GetAll().FirstOrDefault() == default(User))
                throw new UserAlreadyExistsException($"User \"{dto.Username}\" already exists!");

            // Hashing password
            var passwordHashed = PasswordHasher.Hash(dto.Password);

            // Create new User model
            var newUser = new User(dto.Username, passwordHashed);

            // Insert new User to db
            _userRepo.Add(newUser);
        }
        public bool CheckUserData(CreateUserDTO dto)
        {
            return dto.Username == string.Empty || dto.Password == string.Empty;
        }
        public bool CheckPassword(CreateUserDTO dto)
        {
            // Hashing password
            var hash = PasswordHasher.Hash(dto.Password);

            // Get User from db
            var user = _userRepo.GetAll().FirstOrDefault(user => user.Username == dto.Username);
            if (user == null)
            {
                throw new NoUserFoundException("User with given Username doesn't exist!");
            }
            return user.Password == hash;
        }
        public void LoginUser(CreateUserDTO dto)
        {
            // Check if data is valid
            if (dto.Username == string.Empty || dto.Password == string.Empty)
                throw new ArgumentNullException("Empty Username or Password");

            // Get User from db
            var user = _userRepo.GetAll().FirstOrDefault(user => user.Username == dto.Username);
            if (user == null)
            {
                throw new NoUserFoundException("User with given Username doesn't exist!");
            }

            // Check password
            var passwordHashed = PasswordHasher.Hash(dto.Password);
            if (user.Password != passwordHashed)
            {
                throw new UnauthorizedAccessException("Wrong Password!");
            }

            // Generate token for token-based authentication
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Initializes new object of the UserService class
        /// </summary>
        /// <param name="repo">Repository which handles all User data</param>
        public UserService(UserRepository repo)
        {
            _userRepo = repo;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private UserRepository _userRepo;
    }
}
