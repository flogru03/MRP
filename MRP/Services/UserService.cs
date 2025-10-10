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
        public User CreateUser(CreateUserDTO dto)
        {
            // Check if Data is valid
            if (dto.Username == string.Empty || dto.Password == string.Empty) 
                throw new ArgumentNullException($"Empty Username or Password in {nameof(dto)}");

            // Check if User already exists
            // TODO: use linq to get user
            foreach (var user in _userRepo.GetAll())
            {
                if (user.Username == dto.Username)
                    throw new UserAlreadyExistsException($"User \"{dto.Username}\" already exists!");
            }
            
            // Hashing Password
            var passwordHashed = PasswordHasher.Hash(dto.Password);

            // Create new User Model
            var newUser = new User(dto.Username, passwordHashed);

            // Insert new User to DB
            _userRepo.Add(newUser);

            // Return new User Model
            return newUser;
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
