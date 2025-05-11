namespace Backend.Domain.Exceptions
{
    public class BookWasLoanedException : Exception
    {
        private const string DefaultMessage = "server.book_was_Loaned";

        public BookWasLoanedException() : base(DefaultMessage)
        {
        }

        public BookWasLoanedException(string? message) : base(message ?? DefaultMessage)
        {
        }

        public BookWasLoanedException(string? message, Exception? innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
