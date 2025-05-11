using Backend.Application.Books.DTOs.Create;
using Backend.Application.Books.DTOs.Get;

namespace Backend.Application.Books.UseCases.CreateBook
{
    public interface ICreateBookUseCase
    {
        public Task<GetBookDTO> ExecuteAsync(CreateBookDTO bookDTO);
    }
}
