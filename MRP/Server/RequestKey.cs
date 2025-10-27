using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Server
{
    internal record RequestKey
    {
        public string httpMethod { get; init; } = string.Empty;
        public string httpPath {  get; init; } = string.Empty;
    }
}
