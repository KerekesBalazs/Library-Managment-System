using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Exceptions;
using Backend.Infrastructure.Data;

namespace Backend.Application.Books.UseCases.DeleteBook
{
    public class DeleteBookUseCase(
        DataContext _context,
        IBookRepository _bookRepo,
        ILoanRepository _loanRepo
    ) : IDeleteBookUseCase
    {
        public async Task<bool> ExecuteAsync(int id)
        {
            var loans = await _loanRepo.GetLoansByBookIdAsync(id);

            if (loans != null && loans.Count > 0)
            {
                throw new BookWasLoanedException();
            }

            var isDeleted = await _bookRepo.DeleteBookAsync(id);
            _context.SaveChanges();

            return isDeleted;
        }
    }
}
