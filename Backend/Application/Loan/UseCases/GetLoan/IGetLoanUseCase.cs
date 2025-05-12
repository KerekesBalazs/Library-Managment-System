using Backend.Application.Loan.DTOs.Get;

namespace Backend.Application.Loan.UseCases.GetLoan
{
    public interface IGetLoanUseCase
    {
        public Task<GetLoanDTO> ExecuteAsync(int id);
    }
}