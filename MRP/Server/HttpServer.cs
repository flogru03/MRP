using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MRP.Server
{
    public class HttpServer
    {
        private readonly HttpListener _listener;
        private readonly RequestRouter _router;
        private readonly string _prefix;

        public HttpServer(string prefix)
        {
            _prefix = prefix;
            _listener = new HttpListener();
            _listener.Prefixes.Add(_prefix);
            _router = new RequestRouter();
        }

        public void Start()
        {
            _listener.Start();
            Console.WriteLine($"Server läuft auf {_prefix}");

            while (true)
            {
                var context = _listener.GetContext();
                _ = Task.Run(() => _router.HandleRequest(context));
            }
        }
    }
}

