using Backend.Application.Books.DTOs.Get;
using Backend.Application.Books.DTOs.Update;

namespace Backend.Application.Books.UseCases.UpdateBook
{
    public interface IUpdateBookUseCase
    {
        public Task<GetBookDTO> ExecuteAsync(UpdateBookDTO bookDTO);
    }
}
