namespace Backend.Domain.Exceptions
{
    public class BookNotFoundException : Exception
    {
        private const string DefaultMessage = "server.book_not_found";

        public BookNotFoundException() : base(DefaultMessage)
        {
        }

        public BookNotFoundException(string? message) : base(message ?? DefaultMessage)
        {
        }

        public BookNotFoundException(string? message, Exception? innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
