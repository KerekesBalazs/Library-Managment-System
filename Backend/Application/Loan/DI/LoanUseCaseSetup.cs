using Backend.Application.Loan.UseCases.CreateLoan;
using Backend.Application.Loan.UseCases.DeleteLoan;
using Backend.Application.Loan.UseCases.GetLoan;
using Backend.Application.Loan.UseCases.UpdateLoan;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application.Loan.DI
{
    public static class LoanUseCaseSetup
    {
        public static IServiceCollection AddLoanUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateLoanUseCase, CreateLoanUseCase>();
            services.AddScoped<IUpdateLoanUseCase, UpdateLoanUseCase>();
            services.AddScoped<IGetLoanUseCase, GetLoanUseCase>();
            services.AddScoped<IDeleteLoanUseCase, DeleteLoanUseCase>();

            return services;
        }
    }
}
