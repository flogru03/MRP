using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.DTO;
using Npgsql;

namespace MRP.Database
{
    internal class UserRepository : IRepository<UserDTO>
    {
        // ########## METHODS ##########
        public IEnumerable<UserDTO> GetAll()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT id, username, password FROM users");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                yield return new UserDTO
                {
                    Id = reader.GetGuid(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2)
                };
                
            }
        }

        // TODO: implement user repository
        public UserDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
        public UserDTO GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public void Add(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        // ########## CONSTRUCTORS ##########
        public UserRepository(string connectionString)
        {
            _connString = connectionString;
        }

        // ########## MEMBERS ##########
        private string _connString;

        // ########## EXCEPTIONS ##########
        public static Exception UsernameAlreadyUsedException;
    }
}
