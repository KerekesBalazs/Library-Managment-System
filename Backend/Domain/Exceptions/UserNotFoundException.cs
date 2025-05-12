namespace Backend.Domain.Exceptions
{
    public class UserNotFoundException : Exception
    {
        private const string DefaultMessage = "server.user_not_found";

        public UserNotFoundException() : base(DefaultMessage)
        {
        }

        public UserNotFoundException(string? message) : base(message ?? DefaultMessage)
        {
        }

        public UserNotFoundException(string? message, Exception? innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
