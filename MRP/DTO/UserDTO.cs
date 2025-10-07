using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.DTO
{
    // TODO: expand user dto
    // TODO: add user profile dro
    // TODO: add user stats dto
    internal record UserDTO
    {
        public Guid Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
