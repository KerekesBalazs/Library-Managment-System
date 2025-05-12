namespace Backend.Domain.Exceptions
{
    public class LoanNotFoundException : Exception
    {
        private const string DefaultMessage = "server.loan_not_found";

        public LoanNotFoundException() : base(DefaultMessage)
        {
        }

        public LoanNotFoundException(string? message) : base(message ?? DefaultMessage)
        {
        }

        public LoanNotFoundException(string? message, Exception? innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
