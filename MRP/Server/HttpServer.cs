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

        public HttpServer(string prefix, RequestRouter router)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefix);

            _router = router;
        }

        public void Start()
        {
            if (_listener == null) 
                return;

            _listener.Start();

            while (true)
            {
                var context = _listener.GetContext();
                using var _ = Task.Run(() => _router.HandleRequest(context));
            }
        }
    }
}

