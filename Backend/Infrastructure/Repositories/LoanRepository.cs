using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class LoanRepository(
        DataContext _context
    ) : ILoanRepository
    {
        public async Task<Loan> AddLoanAsync(Loan loan)
        {
            var createdLoan = await _context.Loans.AddAsync(loan);
            return createdLoan.Entity;
        }

        public async Task<bool> DeleteLoadAsync(int loanId)
        {
            var affected = await _context.Loans
                .Where(l => l.Id == loanId)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public async Task<Loan?> GetLoanByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<List<Loan>> GetLoansAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<List<Loan>> GetLoansByBookIdAsync(int bookId)
        {
            return await _context.Loans
                .Where(l => l.BookId == bookId)
                .ToListAsync();
        }

        public Loan UpdateLoan(Loan loan)
        {
            _context.Loans.Update(loan);
            return loan;
        }
    }
}
