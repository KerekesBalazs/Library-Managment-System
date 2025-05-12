using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        public Task<Reservation?> GetReservationByIdAsync(int id);

        public Task<List<Reservation>> GetReservationsAsync();

        public Task<Reservation> AddReservationAsync(Reservation reservation);

        public Reservation UpdateReservation(Reservation reservation);

        public Task<bool> DeleteReservationAsync(int reservationId);
    }
}
