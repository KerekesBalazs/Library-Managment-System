using Backend.Application.Loan.DTOs.Create;
using Backend.Application.Loan.DTOs.Get;

namespace Backend.Application.Loan.UseCases.CreateLoan
{
    public interface ICreateLoanUseCase
    {
        public Task<GetLoanDTO> ExecuteAsync(CreateLoanDTO loanDTO);
    }
}
