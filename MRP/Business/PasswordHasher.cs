using Isopoh.Cryptography.Argon2;   // Argon2 Hashing Algorithm
using System.Text;                  // UTF8 Encoding

namespace MRP.Business
{
    /// <summary>
    /// Provides hashing algorithm for storing password on database
    /// </summary>
    internal static class PasswordHasher
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Hashes specified string
        /// </summary>
        /// <param name="password">Password in clear text</param>
        /// <returns>Hashvalue as string</returns>
        public static string Hash(string password)
        {
            Argon2Config config = new Argon2Config
            {
                Type = Argon2Type.DataIndependentAddressing,
                Version = Argon2Version.Nineteen,
                TimeCost = 4,
                MemoryCost = 1024 * 64,
                Lanes = 4,
                Threads = Environment.ProcessorCount,
                Password = Encoding.UTF8.GetBytes(password)
            };

            return Argon2.Hash(config);
        }
    }
}
