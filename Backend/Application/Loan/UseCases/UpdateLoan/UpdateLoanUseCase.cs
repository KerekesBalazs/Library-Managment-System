using AutoMapper;
using Backend.Application.Interfaces.Repositories;
using Backend.Application.Loan.DTOs.Get;
using Backend.Application.Loan.DTOs.Update;
using Backend.Domain.Exceptions;

namespace Backend.Application.Loan.UseCases.UpdateLoan
{
    public class UpdateLoanUseCase(
        ILoanRepository _loanRepo,
        IMapper _mapper
    ) : IUpdateLoanUseCase
    {
        public async Task<GetLoanDTO> ExecuteAsync(UpdateLoanDTO loanDTO)
        {
            var existingLoan = await _loanRepo.GetLoanByIdAsync(loanDTO.Id);
            if (existingLoan is null)
            {
                throw new LoanNotFoundException();
            }

            // Update only relevant properties
            if (loanDTO.ReturnDate.HasValue)
            {
                existingLoan.ReturnDate = loanDTO.ReturnDate.Value;
            }

            var updatedLoan = _loanRepo.UpdateLoan(existingLoan);

            return _mapper.Map<GetLoanDTO>(updatedLoan);
        }
    }
}
