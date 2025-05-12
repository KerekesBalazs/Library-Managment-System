namespace Backend.Application.Interfaces.Repositories
{
    public interface ILoanRepository
    {
        public Task<Backend.Domain.Entities.Loan?> GetLoanByIdAsync(int id);

        public Task<List<Backend.Domain.Entities.Loan>> GetLoansAsync();

        public Task<List<Backend.Domain.Entities.Loan>> GetLoansByBookIdAsync(int bookId);

        public Task<Backend.Domain.Entities.Loan> AddLoanAsync(Backend.Domain.Entities.Loan loan);

        public Backend.Domain.Entities.Loan UpdateLoan(Backend.Domain.Entities.Loan loan);

        public Task<bool> DeleteLoadAsync(int loanId);
    }
}
