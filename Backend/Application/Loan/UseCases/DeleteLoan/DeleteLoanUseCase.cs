using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Exceptions;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Backend.Application.Loan.UseCases.DeleteLoan
{
    public class DeleteLoanUseCase(
        ILogger<DeleteLoanUseCase> _logger,
        DataContext _context,
        ILoanRepository _loanRepo,
        IBookRepository _bookRepo,
        IReservationRepository _reservationRepo
    ) : IDeleteLoanUseCase
    {
        public async Task<bool> ExecuteAsync(int loanId)
        {
            var loan = await _loanRepo.GetLoanByIdAsync(loanId);
            if (loan is null)
            {
                throw new LoanNotFoundException();
            }

            var book = await _bookRepo.GetBookByIdAsync(loan.BookId);
            if (book is null)
            {
                throw new BookNotFoundException();
            }

            var deleted = await _loanRepo.DeleteLoadAsync(loanId);
            if (!deleted)
            {
                return false;
            }

            // Increase book quantity
            book.Quantity += 1;
            _bookRepo.UpdateBook(book);
            await _context.SaveChangesAsync();

            // Check for existing reservations
            var reservations = await _context.Reservations
                .Where(r => r.BookId == book.Id && r.Fulfilled == 0)
                .OrderBy(r => r.RequestDate)
                .ToListAsync();

            if (reservations.Any())
            {
                var reservation = reservations.First();

                var newLoan = new Backend.Domain.Entities.Loan
                {
                    BookId = reservation.BookId,
                    UserId = reservation.UserId,
                    LoanDate = DateTime.UtcNow
                };

                await _context.Loans.AddAsync(newLoan);

                // Mark reservation as fulfilled
                reservation.Fulfilled = 1;
                _context.Reservations.Update(reservation);

                // Decrease book quantity again
                book.Quantity -= 1;
                _bookRepo.UpdateBook(book);

                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
