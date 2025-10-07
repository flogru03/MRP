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
        public User CreateUser(string username, string password)
        {
            // Check if User already exists
            if (_userRepo.GetByUsername(username) != null)
                throw new UserAlreadyExistsException($"User \"{username}\" already exists!");

            // TODO: Creating User-Model before dto

            // Hashing Password
            var passwordHashed = PasswordHasher.Hash(password);

            // Create DTO
            var userDTO = new UserDTO
            {
                Id = Guid.NewGuid(),
                Username = username,
                Password = passwordHashed
            };

            // Insert new User to DB
            _userRepo.Add(userDTO);

            // Return new User Model
            return new User(username, passwordHashed);
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
