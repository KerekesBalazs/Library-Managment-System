using Backend.Application.Books.DTOs.Get;
using WebAPI.DTOModels.Incoming.Book;

namespace Backend.Application.Books.UseCases.GetBooks
{
    public interface IGetBooksUseCase
    {
        Task<IEnumerable<GetBookDTO>> ExecuteAsync(BookFilterDTO filters);
    }
}
