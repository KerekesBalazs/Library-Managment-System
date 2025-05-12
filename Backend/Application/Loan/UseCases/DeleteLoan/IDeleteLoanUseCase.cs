namespace Backend.Application.Loan.UseCases.DeleteLoan
{
    public interface IDeleteLoanUseCase
    {
        Task<bool> ExecuteAsync(int id);
    }
}
