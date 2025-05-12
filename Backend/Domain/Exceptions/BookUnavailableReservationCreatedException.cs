namespace Backend.Domain.Exceptions
{
    public class BookUnavailableReservationCreatedException : Exception
    {
        private const string DefaultMessage = "server.book_unavailable_reservation_created";

        public BookUnavailableReservationCreatedException() : base(DefaultMessage)
        {
        }

        public BookUnavailableReservationCreatedException(string? message) : base(message ?? DefaultMessage)
        {
        }

        public BookUnavailableReservationCreatedException(string? message, Exception? innerException) : base(message ?? DefaultMessage, innerException)
        {
        }
    }
}
