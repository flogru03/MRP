namespace MRP.Business.Models                  
{
    /// <summary>
    /// User Model
    /// </summary>
    internal class User
    {
        /*******************************/
        /*          PROPERTIES         */
        /*******************************/

        /// <summary>
        /// UserID
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// List of EntryIDs of favorite media-entries
        /// </summary>
        public HashSet<Guid> FavoriteEntryIDs { get; set; }

        /****************************/
        /*          METHODS         */
        /****************************/


        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        ///<summary>
        ///Constructor for creating new User
        ///</summary> 
        ///<param name="username">Username</param>
        ///<param name="password">Password</param>
        public User(string username, string password)
        {
            Id = new Guid();
            Username = username;
            Password = password;
            FavoriteEntryIDs = new HashSet<Guid>();
        }

        ///<summary>
        ///Constructor for rehydrating from Database
        ///</summary> 
        internal User(Guid id, string username, string password, HashSet<Guid> favoriteEntryIDs)
        {
            Id = id;
            Username = username;
            Password = password;
            FavoriteEntryIDs = favoriteEntryIDs;
        }
    }
}
