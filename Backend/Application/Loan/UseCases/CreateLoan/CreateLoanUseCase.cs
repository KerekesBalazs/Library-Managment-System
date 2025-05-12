using AutoMapper;
using Backend.Application.Interfaces.Repositories;
using Backend.Application.Loan.DTOs.Create;
using Backend.Application.Loan.DTOs.Get;
using Backend.Domain.Entities;
using Backend.Domain.Exceptions;
using Backend.Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Backend.Application.Loan.UseCases.CreateLoan
{
    public class CreateLoanUseCase(
        ILogger<CreateLoanUseCase> _logger,
        DataContext _context,
        IMapper _mapper,
        IBookRepository _bookRepo,
        IUserRepository _userRepo,
        IReservationRepository _reservationRepo
    ) : ICreateLoanUseCase
    {
        public async Task<GetLoanDTO> ExecuteAsync(CreateLoanDTO loanDTO)
        {
            // Check if user exists
            var user = await _userRepo.GetUserByIdAsync(loanDTO.UserId);
            if (user is null)
            {
                throw new UserNotFoundException();
            }

            // Check if book exists
            var book = await _bookRepo.GetBookByIdAsync(loanDTO.BookId);
            if (book is null)
            {
                throw new BookNotFoundException();
            }

            // If quantity is 0, create a reservation
            if (book.Quantity <= 0)
            {
                var reservation = new Reservation
                {
                    BookId = book.Id,
                    UserId = user.Id,
                    RequestDate = DateTime.UtcNow,
                    Fulfilled = 0
                };

                await _reservationRepo.AddReservationAsync(reservation);
                await _context.SaveChangesAsync();

                throw new BookUnavailableReservationCreatedException();
            }

            // Book is available, proceed with loan
            var loan = new Backend.Domain.Entities.Loan
            {
                BookId = book.Id,
                UserId = user.Id,
                LoanDate = DateTime.UtcNow
            };

            var addedLoan = await _context.Loans.AddAsync(loan);
            book.Quantity -= 1;

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetLoanDTO>(addedLoan.Entity);
        }
    }
}
