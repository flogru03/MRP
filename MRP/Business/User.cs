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
        public string Username { get; set; }
        public string Password { get; set; }

        // TODO: add ratings, fav, stats


        // ########## CONSTRUCTORS ##########
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
