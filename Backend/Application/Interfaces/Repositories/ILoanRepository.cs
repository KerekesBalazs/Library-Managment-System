using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        public Task<Loan?> GetLoanByIdAsync(int id);

        public Task<List<Loan>> GetLoansAsync();

        public Task<List<Loan>> GetLoansByBookIdAsync(int bookId);

        public Task<Loan> AddLoanAsync(Loan loan);

        public Loan UpdateLoan(Loan loan);

        public Task<bool> DeleteLoadAsync(int loanId);
    }
}
