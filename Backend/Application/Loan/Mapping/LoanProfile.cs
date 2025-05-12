using AutoMapper;
using Backend.Application.Loan.DTOs.Common;
using Backend.Application.Loan.DTOs.Create;
using Backend.Application.Loan.DTOs.Get;
using Backend.Application.Loan.DTOs.Update;

namespace Backend.Application.Loan.Mapping
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Backend.Domain.Entities.Loan, BaseLoanDTO>();

            // Incoming
            CreateMap<CreateLoanDTO, Backend.Domain.Entities.Loan>();
            CreateMap<UpdateLoanDTO, Backend.Domain.Entities.Loan>();

            // Outgoing
            CreateMap<Backend.Domain.Entities.Loan, GetLoanDTO>();
        }
    }
}
