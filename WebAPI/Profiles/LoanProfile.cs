using AutoMapper;
using Backend.Application.Loan.DTOs.Common;
using Backend.Application.Loan.DTOs.Create;
using Backend.Application.Loan.DTOs.Get;
using Backend.Application.Loan.DTOs.Update;
using WebAPI.DTOModels.Incoming.Loan;
using WebAPI.DTOModels.Outgoing.Loan;

namespace WebAPI.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<BaseLoanRequest, BaseLoanDTO>();

            // incoming
            CreateMap<CreateLoanRequest, CreateLoanDTO>();
            CreateMap<UpdateLoanRequest, UpdateLoanDTO>();

            // outgoing
            CreateMap<GetLoanDTO, GetLoanResponse>();
        }
    }
}
