using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class ReservationRepository(
        DataContext _context
    ) : IReservationRepository
    {
        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            var createdReservation = await _context.Reservations.AddAsync(reservation);
            await _context.SaveChangesAsync();
            return createdReservation.Entity;
        }

        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            var affected = await _context.Reservations
               .Where(r => r.Id == reservationId)
               .ExecuteDeleteAsync();

            return affected > 0;
        }

        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<List<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public Reservation UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            return reservation;
        }
    }
}
