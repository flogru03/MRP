using System.Net;

namespace MRP.Server
{
    /// <summary>
    /// Implements a simple HTTP-Server using the HttpListener-class
    /// </summary>
    internal class HttpServer
    {
        /****************************/
        /*          METHODS         */
        /****************************/

        /// <summary>
        /// Starts listening to incoming http-requests
        /// </summary>
        public void Start()
        {
            if (_listener == null)
                throw new HttpListenerException();

            _listener.Start();

            // Uses Tasks to delegate request handling asynchronosly
            while (true)
            {
                var context = _listener.GetContext();
                using var _ = Task.Run(() => _router.HandleRequestAsync(context));
            }
        }

        /*********************************/
        /*          CONSTRUCTORS         */
        /*********************************/

        /// <summary>
        /// Initializes new instance of the HttpServer-class
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="router"></param>
        public HttpServer(string prefix, RequestRouter router)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefix);
            _router = router;
        }

        /****************************/
        /*          MEMBERS         */
        /****************************/
        private readonly HttpListener _listener;
        private readonly RequestRouter _router;
    }
}

