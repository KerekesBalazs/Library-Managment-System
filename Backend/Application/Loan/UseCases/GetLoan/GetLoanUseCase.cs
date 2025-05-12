using AutoMapper;
using Backend.Application.Interfaces.Repositories;
using Backend.Application.Loan.DTOs.Get;
using Backend.Domain.Exceptions;

namespace Backend.Application.Loan.UseCases.GetLoan
{
    public class GetLoanUseCase(
        ILoanRepository _loanRepo,
        IMapper _mapper
    ) : IGetLoanUseCase
    {
        public async Task<GetLoanDTO> ExecuteAsync(int id)
        {
            var loan = await _loanRepo.GetLoanByIdAsync(id);
            if (loan is null)
            {
                throw new LoanNotFoundException();
            }

            return _mapper.Map<GetLoanDTO>(loan);
        }
    }
}
