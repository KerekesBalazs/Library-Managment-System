namespace Backend.Application.Books.UseCases.DeleteBook
{
    public interface IDeleteBookUseCase
    {
        Task<bool> ExecuteAsync(int id);
    }
}
