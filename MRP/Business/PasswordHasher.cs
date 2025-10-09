using Isopoh.Cryptography.Argon2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Business
{
    internal static class PasswordHasher
    {
        // TODO: add comments

        // ########## PROPERTIES ##########
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
