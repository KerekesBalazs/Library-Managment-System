using Backend.Application.Loan.DTOs.Get;
using Backend.Application.Loan.DTOs.Update;

namespace Backend.Application.Loan.UseCases.UpdateLoan
{
    public interface IUpdateLoanUseCase
    {
        public Task<GetLoanDTO> ExecuteAsync(UpdateLoanDTO loanDTO);
    }
}
