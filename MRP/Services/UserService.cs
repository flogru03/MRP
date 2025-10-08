using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MRP.Business;
using MRP.Database;
using MRP.DTO;
using Isopoh.Cryptography.Argon2;

namespace MRP.Services
{
    internal class UserService
    {
        // ########## METHODS ##########
        public User CreateUser(CreateUserDTO dto)
        {
            // Check if Data is valid
            if (dto.Username == string.Empty || dto.Password == string.Empty) 
                throw new ArgumentNullException($"Empty Username or Password in {nameof(dto)}");

            // Check if User already exists
            if (_userRepo.GetByUsername(dto.Username) != null)
                throw new UserAlreadyExistsException($"User \"{dto.Username}\" already exists!");

            // Hashing Password
            var passwordHashed = PasswordHasher.Hash(dto.Password);

            // Create new User Model
            var newUser = new User(dto.Username, passwordHashed);

            // Insert new User to DB
            _userRepo.Add(newUser);

            // Return new User Model
            return newUser;
        }

        // ########## CONSTRUCTORS ##########
        public UserService(UserRepository repo)
        {
            _userRepo = repo;
        }

        // ########## MEMBERS ##########
        private UserRepository _userRepo;
    }
}
