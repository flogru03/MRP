using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MRP.Business;
using Npgsql;

namespace MRP.Database
{
    internal class UserRepository : IRepository<User>
    {
        // ########## METHODS ##########
        public IEnumerable<User> GetAll()
        {
            using var conn = new NpgsqlConnection(_connString);
            conn.Open();

            using var cmd = new NpgsqlCommand("SELECT id, username, password FROM users");
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                yield return new User
                (
                    reader.GetGuid(0),
                    reader.GetString(1),
                    reader.GetString(2)
                );
                
            }
        }

        // TODO: implement user repository

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        User IRepository<User>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
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
