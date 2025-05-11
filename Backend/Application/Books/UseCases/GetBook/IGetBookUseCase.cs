using Backend.Application.Books.DTOs.Get;

namespace Backend.Application.Books.UseCases.GetBook
{
    public interface IGetBookUseCase
    {
        public Task<GetBookDTO> ExecuteAsync(int id);
    }
}
