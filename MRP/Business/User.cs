using MRP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business                  
{
    internal class User
    {
        // ########## PROPERTIES ##########
        public Guid Id { get; }
        public string Username { get; set; }
        public string Password { get; private set; }
        public List<Guid> FavoriteEntryIDs { get; private set; }

        // ########## METHODS ##########   
        

        // ########## CONSTRUCTORS ##########
        public User(string username, string password)
        {
            Id = new Guid();
            Username = username;
            Password = password;
            FavoriteEntryIDs = new List<Guid>();
        }
    }
}
