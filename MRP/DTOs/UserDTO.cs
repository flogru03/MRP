using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.DTO
{
    internal record UserDTO
    {
        public Guid Id { get; init; }
        public string Username { get; init; } = string.Empty;
    }
}
