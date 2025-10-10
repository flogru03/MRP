namespace MRP.Business
{
    internal class NoUserFoundException : Exception
    {
        public NoUserFoundException()
        {
        }

        public NoUserFoundException(string? message) : base(message)
        {
        }

        public NoUserFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
