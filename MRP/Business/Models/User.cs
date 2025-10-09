using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business.Models                  
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

        ///<summary>
        ///Constructor for creating new User
        ///</summary> 
        public User(string username, string password)
        {
            Id = new Guid();
            Username = username;
            Password = password;
            FavoriteEntryIDs = new List<Guid>();
        }

        ///<summary>
        ///Constructor for rehydrating from Database
        ///</summary> 
        internal User(Guid id, string username, string password, List<Guid> favoriteEntryIDs)
        {
            Id = id;
            Username = username;
            Password = password;
            FavoriteEntryIDs = favoriteEntryIDs;
        }
    }
}
